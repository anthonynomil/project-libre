using Models.Abstract;
using Models.Enum;
using Models.Interface;

namespace Models;

public sealed class ResultAggregator
{
    private readonly List<IResult> _results = [];

    public void AddResultRange(params IResult[] result) => _results.AddRange(result);

    public Result ToSingleResult(
        ApplicationResultCodeEnum successCode,
        ApplicationResultCodeEnum errorCode
    )
    {
        var nestedErrors = _results
            .Where(IsRegularError)
            .Select(result => result)
            .Concat(_results
                .Where(IsPopulationError)
                .SelectMany(result => result.NestedResults))
            .ToList();

        return nestedErrors.Count == 0
            ? Result.Success(successCode)
            : Result.Error(errorCode, nestedErrors);
    }

    public sealed class Result : BaseResult, IResult
    {
        private Result(
            bool isSuccessful,
            ApplicationResultCodeEnum applicationResultCodeCode,
            string message,
            in IEnumerable<IResult> errors
        )
            : base(isSuccessful, applicationResultCodeCode, message)
        {
            Message = message;
            NestedResults.AddRange(errors);
        }

        public static Result Success(ApplicationResultCodeEnum applicationResultCodeCode) =>
            new(true, applicationResultCodeCode, "", []);

        public static Result Error(
            ApplicationResultCodeEnum applicationResultCodeCode,
            IEnumerable<IResult> errors
        ) => new(false, applicationResultCodeCode, ResultMessage.Validation(), errors);
    }

    private static bool IsRegularError(IResult result)
    {
        return result.IsSuccessful == false && result.ApplicationResultCodeCode != ApplicationResultCodeEnum.PopulationError;
    }

    private static bool IsPopulationError(IResult result)
    {
        return result is { IsSuccessful: false, ApplicationResultCodeCode: ApplicationResultCodeEnum.PopulationError };
    }
}

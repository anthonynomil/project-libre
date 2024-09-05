using Models.Enum;
using Models.Interface;

namespace Models.Abstract;

public abstract class BaseResult(bool isSuccessful, ApplicationResultCodeEnum applicationResultCodeCode, string message)
{
    public bool IsSuccessful { get; protected init; } = isSuccessful;
    public ApplicationResultCodeEnum ApplicationResultCodeCode { get; protected init; } = applicationResultCodeCode;
    public string Message { get; protected init; } = message;
    public List<IResult> NestedResults { get; } = [];

    public IEnumerable<IResult> GetNestedErrors() => NestedResults.Where(nestedResult => nestedResult.IsSuccessful == false);
}

using Models.Abstract;
using Models.Enum;
using Models.Interface;

namespace Models;

public sealed class ResultError : BaseResult, IResult
{
    private ResultError(ApplicationResultCodeEnum applicationResultCodeCode, string message)
        : base(false, applicationResultCodeCode, message) { }

    public static ResultError AlreadyExists() =>
        new(ApplicationResultCodeEnum.AlreadyExists, ResultMessage.AlreadyExists());

    public static ResultError NotFound() =>
        new(ApplicationResultCodeEnum.NotFound, ResultMessage.NotFound());

    public static ResultError Validation() =>
        new(ApplicationResultCodeEnum.ValidationError, ResultMessage.Validation());
}

public sealed class ResultError<T> : BaseResult, IResult<T>
    where T : class
{
    public T? Value { get; }

    private ResultError(ApplicationResultCodeEnum applicationResultCodeCode, string message)
        : base(false, applicationResultCodeCode, message)
    {
        IsSuccessful = false;
        ApplicationResultCodeCode = applicationResultCodeCode;
        Value = null;
    }

    public static ResultError<T> NotFound() =>
        new(ApplicationResultCodeEnum.NotFound, ResultMessage.NotFound());

    public static ResultError<T> InvalidCredentials() =>
        new(ApplicationResultCodeEnum.InvalidCredentials, ResultMessage.InvalidCredentials());
}

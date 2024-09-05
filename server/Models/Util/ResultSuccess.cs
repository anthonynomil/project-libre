using Models.Abstract;
using Models.Enum;
using Models.Interface;

namespace Models;

public sealed class ResultSuccess : BaseResult, IResult
{
    private ResultSuccess(ApplicationResultCodeEnum applicationResultCodeCode, string message)
        : base(false, applicationResultCodeCode, message)
    {
        IsSuccessful = true;
        ApplicationResultCodeCode = applicationResultCodeCode;
    }

    public static ResultSuccess Created() =>
        new(ApplicationResultCodeEnum.Created, ResultMessage.Created());

    public static ResultSuccess Deleted() =>
        new(ApplicationResultCodeEnum.Deleted, ResultMessage.Deleted());

    public static ResultSuccess Populated() =>
        new(ApplicationResultCodeEnum.Populated, "Populated");

    public static ResultSuccess Updated() =>
        new(ApplicationResultCodeEnum.Updated, ResultMessage.Updated());
}

public sealed class ResultSuccess<T> : BaseResult, IResult<T>
    where T : class
{
    public T? Value { get; }

    private ResultSuccess(
        ApplicationResultCodeEnum applicationResultCodeCode,
        string message,
        T value
    )
        : base(false, applicationResultCodeCode, message)
    {
        IsSuccessful = true;
        ApplicationResultCodeCode = applicationResultCodeCode;
        Value = value;
    }

    public static ResultSuccess<T> Retrieved(T value, string message = "") =>
        new(ApplicationResultCodeEnum.Retrieved, message, value);
}

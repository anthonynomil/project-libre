using Models.Enum;

namespace Models.Interface;

public interface IResult
{
    public bool IsSuccessful { get; }
    public ApplicationResultCodeEnum ApplicationResultCodeCode { get; }
    public string Message { get; }
    public List<IResult> NestedResults { get; }

    public IEnumerable<IResult> GetNestedErrors();
}

public interface IResult<out T> : IResult
    where T : class
{
    public T? Value { get; }
}

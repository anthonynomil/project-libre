namespace Infrastructure.Interface;

public interface IEnvelop
{
    public DateTimeOffset GeneratedAt { get; init; }
    public string? Message { get; init; }
    public IEnumerable<string> Warnings { get; init; }
}

public interface IEnvelop<T> : IEnvelop
    where T : class
{
    public T? Value { get; init; }
}

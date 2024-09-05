namespace Models.Interface;

public interface IPagedListParameters
{
    public int Limit { get; }
    public int Page { get; }
}

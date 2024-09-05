using Models.Interface;

namespace Models.Abstract;

public abstract class PagedListParameters(int? limit, int? page) : IPagedListParameters
{
    public int Limit { get; init; } = limit ?? 10;
    public int Page { get; init; } = page ?? 0;
}

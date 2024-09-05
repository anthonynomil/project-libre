using Models.Abstract;

namespace Models;

public class CountryDtoPagedListParameters(int? limit, int? page)
    : PagedListParameters(limit, page);

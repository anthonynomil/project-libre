using Models.Abstract;

namespace Models;

public class CompanyDtoPagedListParameters(int? limit, int? page)
    : PagedListParameters(limit, page);

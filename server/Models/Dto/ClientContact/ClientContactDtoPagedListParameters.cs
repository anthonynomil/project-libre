using Models.Abstract;

namespace Models;

public class ClientContactDtoPagedListParameters(int? limit, int? page)
    : PagedListParameters(limit, page);

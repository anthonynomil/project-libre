using Models.Abstract;

namespace Models;

public class UserDtoPagedListParameters(int? limit, int? page) : PagedListParameters(limit, page);

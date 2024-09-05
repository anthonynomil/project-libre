using Models.Abstract;

namespace Models;

public class CityDtoPagedListParameters(int? limit, int? page) : PagedListParameters(limit, page);

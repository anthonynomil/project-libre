using Models.Abstract;

namespace Models;

public class ContactInformationDtoPagedListParameters(int? limit, int? page)
    : PagedListParameters(limit, page);

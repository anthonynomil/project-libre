using Models.Interface;

namespace Models;

public class CompanyDtoCreate : IAddressableDtoCreate, IChargeableDtoCreate
{
    public required string BusinessName { get; init; }

    public int? CountryId { get; init; }

    public AddressDtoCreate? Address { get; init; }

    public BankDetailsDtoCreate? BankDetails { get; init; }

    public IEnumerable<ClientContactDtoCreate>? Contacts { get; init; }

    public ClientFinancialInformationDtoCreate? FinancialInformation { get; init; }
}

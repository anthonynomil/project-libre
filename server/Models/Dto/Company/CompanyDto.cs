using Entities;

namespace Models;

public class CompanyDto
{
    public required int Id { get; init; }
    public required string BusinessName { get; init; }
    public required CountryDto? Country { get; init; }
    public required AddressDto? Address { get; init; }
    public required BankDetailsDto? BankDetails { get; init; }
    public required IEnumerable<ClientContactDto>? Contacts { get; init; }
    public required ClientFinancialInformationDto? FinancialInformation { get; init; }

    public static CompanyDto From(Company company) =>
        new()
        {
            Id = company.Id,
            BusinessName = company.BusinessName,
            Country = company.Country.ToDtoOrDefault(CountryDto.From),
            Address = company.Address.ToDtoOrDefault(AddressDto.From),
            BankDetails = company.BankDetails.ToDtoOrDefault(BankDetailsDto.From),
            Contacts = company.Contacts.ToDtoOrDefault(ClientContactDto.From),
            FinancialInformation = company.FinancialInformation.ToDtoOrDefault(
                ClientFinancialInformationDto.From
            )
        };

    public static IEnumerable<CompanyDto> From(IEnumerable<Company> companies) =>
        companies.Select(From);
}

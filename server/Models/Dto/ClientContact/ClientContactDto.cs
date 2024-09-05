using Entities;

namespace Models;

public class ClientContactDto
{
    public required int Id { get; init; }
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required DateOnly? Birthdate { get; init; }
    public required CountryDto? Country { get; init; }
    public required AddressDto? Address { get; init; }
    public required ContactInformationDto? ContactInformation { get; init; }

    public static ClientContactDto From(ClientContact clientContact) =>
        new()
        {
            Id = clientContact.Id,
            Firstname = clientContact.Firstname,
            Lastname = clientContact.Lastname,
            Birthdate = clientContact.Birthdate,
            Address = clientContact.Address.ToDtoOrDefault(AddressDto.From),
            Country = clientContact.Country.ToDtoOrDefault(CountryDto.From),
            ContactInformation = clientContact.ContactInformation.ToDtoOrDefault(
                ContactInformationDto.From
            )
        };

    public static IEnumerable<ClientContactDto> From(IEnumerable<ClientContact> clientContacts) =>
        clientContacts.Select(From);
}

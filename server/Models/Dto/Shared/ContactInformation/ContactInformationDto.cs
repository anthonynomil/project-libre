using Entities;

namespace Models;

public class ContactInformationDto
{
    public required int Id { get; init; }
    public required string? MailAddress { get; init; }
    public required string? PhoneNumber { get; init; }

    public static ContactInformationDto From(ContactInformation contactInformation) =>
        new()
        {
            Id = contactInformation.Id,
            MailAddress = contactInformation.MailAddress,
            PhoneNumber = contactInformation.PhoneNumber
        };

    public static IEnumerable<ContactInformationDto> From(
        IEnumerable<ContactInformation> contactInformation
    ) => contactInformation.Select(From);
}

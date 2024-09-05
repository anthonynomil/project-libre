using Models.Interface;

namespace Models.Abstract;

public abstract class PersonDtoCreate : IAddressableDtoCreate, IContactableDtoCreate
{
    public required string Firstname { get; init; }

    public required string Lastname { get; init; }

    public DateOnly? Birthdate { get; init; }

    public int? CountryId { get; init; }

    public AddressDtoCreate? Address { get; init; }

    public ContactInformationDtoCreate? ContactInformation { get; init; }
}

using Entities;

namespace Models;

public class AddressDto
{
    public required int Id { get; init; }
    public required CityDto City { get; init; }
    public required int Number { get; init; }
    public required string? NumberComplement { get; init; }
    public required string Road { get; init; }

    public static AddressDto From(Address address) =>
        new()
        {
            Id = address.Id,
            City = CityDto.From(address.City),
            Number = address.Number,
            NumberComplement = address.NumberComplement,
            Road = address.Road
        };
}

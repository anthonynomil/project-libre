using Entities;

namespace Models;

public class CityDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string PostalCode { get; init; }

    public static CityDto From(City city) =>
        new()
        {
            Id = city.Id,
            Name = city.Name,
            PostalCode = city.PostalCode
        };

    public static IEnumerable<CityDto> From(IEnumerable<City> cities) => cities.Select(From);
}

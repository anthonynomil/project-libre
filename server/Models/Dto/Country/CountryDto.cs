using Entities;

namespace Models;

public class CountryDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string FlagSvg { get; init; }

    public static CountryDto From(Country country) =>
        new()
        {
            Id = country.Id,
            Name = country.Name,
            FlagSvg = country.FlagSvg
        };

    public static IEnumerable<CountryDto> From(IEnumerable<Country> countries) =>
        countries.Select(From);
}

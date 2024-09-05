using System.ComponentModel.DataAnnotations;

namespace Models;

public class CountryDtoCreate
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string FlagSvg { get; init; }
}

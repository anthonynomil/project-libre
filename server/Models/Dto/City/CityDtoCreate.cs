using System.ComponentModel.DataAnnotations;

namespace Models;

public class CityDtoCreate
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string PostalCode { get; init; }
}

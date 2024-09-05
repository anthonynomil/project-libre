using System.ComponentModel.DataAnnotations;
using Models.Abstract;

namespace Models;

public class UserDtoCreate : PersonDtoCreate
{
    [Required]
    [EmailAddress]
    public required string Email { get; init; }

    [Required]
    [StringLength(64, MinimumLength = 8)]
    public required string Password { get; init; }
}

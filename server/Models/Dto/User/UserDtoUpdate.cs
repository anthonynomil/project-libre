using System.ComponentModel.DataAnnotations;

namespace Models;

public class UserDtoUpdate
{
    [EmailAddress]
    public string? Email { get; init; }

    [StringLength(64, MinimumLength = 8)]
    public string? Password { get; init; }
}

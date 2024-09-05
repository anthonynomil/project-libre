using System.ComponentModel.DataAnnotations;

namespace Models;

public sealed class AuthenticationDtoLogin
{
    [EmailAddress]
    public required string Email { get; init; }

    [StringLength(64, MinimumLength = 8)]
    public required string Password { get; init; }
}

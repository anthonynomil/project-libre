namespace Models;

public sealed class AuthenticationDto
{
    public required UserDto User { get; init; }
    public required string Token { get; init; }
}

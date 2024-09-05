using Entities;

namespace Models;

public class UserDto
{
    public required int Id { get; init; }
    public required string Email { get; init; }
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public required IEnumerable<UserRoleDto> UserRoles { get; init; }
    public required DateOnly? Birthdate { get; init; }
    public required CountryDto? Country { get; init; }
    public required AddressDto? Address { get; init; }
    public required ContactInformationDto? ContactInformation { get; init; }

    public static UserDto From(User user) =>
        new()
        {
            Id = user.Id,
            Email = user.Email,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            UserRoles = user.UserRoles.ToDtoOrDefault(UserRoleDto.From),
            Birthdate = user.Birthdate,
            Address = user.Address.ToDtoOrDefault(AddressDto.From),
            Country = user.Country.ToDtoOrDefault(CountryDto.From),
            ContactInformation = user.ContactInformation.ToDtoOrDefault(ContactInformationDto.From)
        };

    public static IEnumerable<UserDto> From(IEnumerable<User> users) => users.Select(From);
}

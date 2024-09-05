using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class User : Person, ITimestampedEntity
{
    private string _email = null!;
    private string _password = null!;
    public ICollection<UserRole> UserRoles { get; init; } = new List<UserRole>();

    private User() { }

    public User(
        string email,
        string password,
        string firstname,
        string lastname,
        params UserRole[] userRole
    )
        : base(firstname, lastname)
    {
        Email = email;
        Password = password;

        foreach (var userRoleEnum in userRole)
        {
            UserRoles.Add(userRoleEnum);
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            EntityValidator.RequiredString(value, nameof(Email));
            _email = value;
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            EntityValidator.RequiredString(value, nameof(Password));
            _password = value;
        }
    }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

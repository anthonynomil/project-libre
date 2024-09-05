using Entities.Abstract;
using Entities.Enum;

namespace Entities;

public class UserRole : PrimaryKey
{
    public UserRoleEnum Value { get; private init; }

    public UserRole(UserRoleEnum value)
    {
        Value = value;
    }

    private UserRole() { }
}

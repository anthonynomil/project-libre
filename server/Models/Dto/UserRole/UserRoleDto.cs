using Entities;
using Entities.Enum;

namespace Models;

public class UserRoleDto
{
    public required int Id { get; init; }
    public required UserRoleEnum Value { get; init; }

    public static UserRoleDto From(UserRole userRole) =>
        new() { Id = userRole.Id, Value = userRole.Value };
}

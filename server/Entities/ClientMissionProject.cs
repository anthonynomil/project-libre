using Entities.Abstract;
using Entities.Enum;
using Entities.Helper;

namespace Entities;

public class ClientMissionProject : PrimaryKey, ITimestampedEntity
{
    private string _name = null!;
    private string? _description;

    private ClientMissionProject() { }

    public ClientMissionProject(string name)
    {
        Name = name;
    }

    public string Name
    {
        get => _name;
        set
        {
            EntityValidator.RequiredString(value, nameof(Name));
            _name = value;
        }
    }

    public string? Description
    {
        get => _description;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(Description));

            _description = value;
        }
    }

    public DateOnly? Deadline { get; set; }

    public ICollection<ClientMissionProjectMilestone>? Milestones { get; init; }

    public ProjectStatusEnum Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

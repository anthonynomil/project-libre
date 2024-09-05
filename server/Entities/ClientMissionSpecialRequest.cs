using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class ClientMissionSpecialRequest : PrimaryKey, ITimestampedEntity
{
    private DateOnly _date;
    private string _description = null!;

    private ClientMissionSpecialRequest() { }

    public ClientMissionSpecialRequest(DateOnly date, string description)
    {
        Date = date;
        Description = description;
    }

    public DateOnly Date
    {
        get => _date;
        set => _date = value;
    }

    public string Description
    {
        get => _description;
        set
        {
            EntityValidator.RequiredString(value, nameof(Description));
            _description = value;
        }
    }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

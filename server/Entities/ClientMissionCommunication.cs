using Entities.Abstract;
using Entities.Enum;

namespace Entities;

public class ClientMissionCommunication : PrimaryKey, ITimestampedEntity
{
    private ClientMissionCommunication() { }

    public ClientMissionCommunication(CommunicationTypeEnum type, DateOnly date, string note)
    {
        Type = type;
        Date = date;
        Note = note;
    }

    public CommunicationTypeEnum Type { get; set; }
    public DateOnly Date { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

using Entities.Abstract;

namespace Entities;

public class ClientMissionContract : PrimaryKey, ITimestampedEntity
{
    private ClientMissionContract() { }

    public ClientMissionContract(string content) { }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

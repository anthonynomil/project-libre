using Entities.Abstract;

namespace Entities;

public class ClientMission : PrimaryKey, ITimestampedEntity
{
    private ClientMission() { }

    public ClientMission(string content) { }

    public ClientMissionProject? Project { get; set; }
    public ICollection<ClientMissionCommunication>? CommunicationsHistory { get; set; }
    public ICollection<ClientMissionContract>? Contracts { get; set; }
    public ICollection<Quotation>? Quotations { get; set; }
    public ICollection<Invoice>? Invoices { get; set; }
    public ICollection<ClientMissionSpecialRequest>? SpecialRequests { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

namespace Entities;

public interface IClient : IAddressable, IChargeable
{
    public string BusinessName { get; set; }
    public ICollection<ClientContact>? Contacts { get; set; }
}

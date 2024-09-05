namespace Entities;

public interface IAddressable
{
    public Country? Country { get; set; }
    public Address? Address { get; set; }
}

namespace Models.Interface;

public interface IAddressableDtoCreate
{
    public int? CountryId { get; }
    public AddressDtoCreate? Address { get; }
}

namespace Entities;

public interface IChargeable
{
    public BankDetails? BankDetails { get; set; }
    public bool IsChargeable();
}

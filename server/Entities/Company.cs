using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class Company : PrimaryKey, IClient
{
    private string _businessName = null!;

    private Company() { }

    public Company(string businessName)
    {
        BusinessName = businessName;
    }

    public string BusinessName
    {
        get => _businessName;
        set
        {
            EntityValidator.RequiredString(value, nameof(BusinessName));
            _businessName = value;
        }
    }

    public Country? Country { get; set; }
    public Address? Address { get; set; }
    public BankDetails? BankDetails { get; set; }
    public ICollection<ClientContact>? Contacts { get; set; }
    public ICollection<ClientMission>? ClientMissions { get; set; }
    public ClientFinancialInformation? FinancialInformation { get; set; }

    public bool IsChargeable()
    {
        return BankDetails?.Bic != null || BankDetails?.Iban != null;
    }
}

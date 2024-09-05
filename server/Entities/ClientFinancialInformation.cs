using Entities.Abstract;
using Entities.Enum;
using Entities.Helper;

namespace Entities;

public class ClientFinancialInformation : PrimaryKey
{
    private int _budget;

    private ClientFinancialInformation() { }

    public ClientFinancialInformation(int budget, PaymentMethodEnum paymentMethod)
    {
        Budget = budget;
        PaymentMethod = paymentMethod;
    }

    public int Budget
    {
        get => _budget;
        set
        {
            EntityValidator.PositiveInteger(value, nameof(Budget));
            _budget = value;
        }
    }

    public PaymentMethodEnum PaymentMethod { get; set; }
}

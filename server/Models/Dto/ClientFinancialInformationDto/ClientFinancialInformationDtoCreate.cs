using Entities.Enum;

namespace Models;

public class ClientFinancialInformationDtoCreate
{
    public required int Budget { get; init; }
    public required PaymentMethodEnum PaymentMethod { get; init; }
}

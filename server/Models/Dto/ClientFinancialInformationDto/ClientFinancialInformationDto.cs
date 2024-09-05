using Entities;
using Entities.Enum;

namespace Models;

public class ClientFinancialInformationDto
{
    public required int Id { get; init; }
    public required int Budget { get; init; }
    public required PaymentMethodEnum PaymentMethod { get; init; }

    public static ClientFinancialInformationDto From(
        ClientFinancialInformation clientFinancialInformation
    ) =>
        new()
        {
            Id = clientFinancialInformation.Id,
            Budget = clientFinancialInformation.Budget,
            PaymentMethod = clientFinancialInformation.PaymentMethod
        };
}

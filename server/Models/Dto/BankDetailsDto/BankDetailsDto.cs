using Entities;

namespace Models;

public class BankDetailsDto
{
    public required int Id { get; init; }
    public required string? Bic { get; init; }
    public required string? Iban { get; init; }

    public static BankDetailsDto From(BankDetails bankDetails) =>
        new()
        {
            Id = bankDetails.Id,
            Bic = bankDetails.Bic,
            Iban = bankDetails.Iban,
        };
}

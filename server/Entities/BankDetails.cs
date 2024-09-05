using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class BankDetails : PrimaryKey
{
    private string? _bic;
    private string? _iban;

    private BankDetails() { }

    public BankDetails(string? bic, string? iban)
    {
        Bic = bic;
        Iban = iban;
    }

    public string? Bic
    {
        get => _bic;
        set
        {
            if (value != null)
                EntityValidator.RequiredString(value, nameof(Bic));
            _bic = value;
        }
    }

    public string? Iban
    {
        get => _iban;
        set
        {
            if (value != null)
                EntityValidator.RequiredString(value, nameof(Iban));
            _iban = value;
        }
    }
}

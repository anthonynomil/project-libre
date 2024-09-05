using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class CompanyFranceSpecifics : PrimaryKey
{
    private Company _company = null!;
    private string? _codeSiret;
    private string? _siren;
    private string? _nomenclatureActiviteFrancaise;
    private string? _numeroTea;
    private string? _rib;

    private CompanyFranceSpecifics() { }

    public CompanyFranceSpecifics(
        Company company,
        string? codeSiret,
        string? siren,
        string? nomenclatureActiviteFrancaise,
        string? numeroTea,
        string? rib
    )
    {
        Company = company;
        CodeSiret = codeSiret;
        Siren = siren;
        NomenclatureActiviteFrancaise = nomenclatureActiviteFrancaise;
        NumeroTea = numeroTea;
        Rib = rib;
    }

    public Company Company
    {
        get => _company;
        set => _company = value;
    }

    public string? CodeSiret
    {
        get => _codeSiret;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(CodeSiret));
            _codeSiret = value;
        }
    }

    public string? Siren
    {
        get => _siren;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(Siren));
            _siren = value;
        }
    }

    public string? NomenclatureActiviteFrancaise
    {
        get => _nomenclatureActiviteFrancaise;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(NomenclatureActiviteFrancaise));
            _nomenclatureActiviteFrancaise = value;
        }
    }

    public string? NumeroTea
    {
        get => _numeroTea;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(NumeroTea));
            _numeroTea = value;
        }
    }

    public string? Rib
    {
        get => _rib;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(Rib));
            _rib = value;
        }
    }
}

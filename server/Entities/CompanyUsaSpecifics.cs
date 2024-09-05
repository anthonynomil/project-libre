using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class CompanyUsaSpecifics : PrimaryKey
{
    private Company _company = null!;
    private string? _centralIndexKey;

    private CompanyUsaSpecifics() { }

    public CompanyUsaSpecifics(Company company, string? centralIndexKey)
    {
        Company = company;
        CentralIndexKey = centralIndexKey;
    }

    public Company Company
    {
        get => _company;
        set => _company = value;
    }

    public string? CentralIndexKey
    {
        get => _centralIndexKey;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(CentralIndexKey));

            _centralIndexKey = value;
        }
    }
}

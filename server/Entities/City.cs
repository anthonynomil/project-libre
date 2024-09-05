using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class City : PrimaryKey
{
    private string _name = null!;
    private string _postalCode = null!;

    private City() { }

    public City(string name, string postalCode)
    {
        Name = name;
        PostalCode = postalCode;
    }

    public string Name
    {
        get => _name;
        set
        {
            EntityValidator.RequiredString(value, nameof(Name));
            _name = value;
        }
    }

    public string PostalCode
    {
        get => _postalCode;
        set
        {
            EntityValidator.RequiredString(value, nameof(PostalCode));
            _postalCode = value;
        }
    }
}

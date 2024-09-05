using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class Country : PrimaryKey
{
    private string _name = null!;
    private string _flagSvg = null!;

    private Country() { }

    public Country(string name, string flagSvg)
    {
        Name = name;
        FlagSvg = flagSvg;
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

    public string FlagSvg
    {
        get => _flagSvg;
        set
        {
            EntityValidator.RequiredString(value, nameof(FlagSvg));
            _flagSvg = value;
        }
    }
}

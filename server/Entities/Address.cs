using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class Address : PrimaryKey
{
    private int _number;
    private string? _numberComplement;
    private string _road = null!;

    private Address() { }

    public Address(City city, int number, string? numberComplement, string road)
    {
        City = city;
        Number = number;
        NumberComplement = numberComplement;
        Road = road;
    }

    public City City { get; set; } = null!;

    public int Number
    {
        get => _number;
        set
        {
            EntityValidator.PositiveInteger(value, nameof(Number));
            _number = value;
        }
    }

    public string? NumberComplement
    {
        get => _numberComplement;
        set
        {
            if (value != default)
                EntityValidator.RequiredString(value, nameof(NumberComplement));
            _numberComplement = value;
        }
    }

    public string Road
    {
        get => _road;
        set
        {
            EntityValidator.RequiredString(value, nameof(Road));
            _road = value;
        }
    }
}

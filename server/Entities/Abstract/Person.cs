using Entities.Helper;

namespace Entities.Abstract;

public abstract class Person : PrimaryKey, IAddressable, IContactable
{
    private string _firstname = null!;
    private string _lastname = null!;
    private DateOnly? _birthdate;

    protected Person() { }

    protected Person(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }

    public string Firstname
    {
        get => _firstname;
        set
        {
            EntityValidator.RequiredString(value, nameof(Firstname));
            _firstname = value;
        }
    }

    public string Lastname
    {
        get => _lastname;
        set
        {
            EntityValidator.RequiredString(value, nameof(Lastname));
            _lastname = value;
        }
    }

    public DateOnly? Birthdate
    {
        get => _birthdate;
        set
        {
            if (value.HasValue)
                EntityValidator.ValidBirthdate(value.Value, nameof(Birthdate));
            _birthdate = value;
        }
    }

    public Country? Country { get; set; }
    public Address? Address { get; set; }
    public ContactInformation? ContactInformation { get; set; }
}

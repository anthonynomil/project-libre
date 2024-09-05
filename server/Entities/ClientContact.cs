using Entities.Abstract;

namespace Entities;

public class ClientContact : Person
{
    private ClientContact() { }

    public ClientContact(string firstname, string lastname)
        : base(firstname, lastname) { }
}

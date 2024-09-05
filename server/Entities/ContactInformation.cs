using Entities.Abstract;

namespace Entities;

public class ContactInformation : PrimaryKey
{
    private ContactInformation() { }

    public ContactInformation(string? phoneNumber, string? mailAddress)
    {
        MailAddress = mailAddress;
        PhoneNumber = phoneNumber;
    }

    public string? MailAddress { get; set; }
    public string? PhoneNumber { get; set; }
}

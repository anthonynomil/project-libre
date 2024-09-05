using Entities.Abstract;

namespace Entities.UnitTests;

public class UserTest
{
    private User _user = null!;
    private const string Email = "test@email.com";
    private const string Password = "password";
    private const string Firstname = "firstname";
    private const string Lastname = "lastname";

    [SetUp]
    public void Setup()
    {
        _user = new User(Email, Password, Firstname, Lastname);
    }

    [Test]
    public void Should_Inherit_From_PrimaryKey()
    {
        Assert.That(typeof(User).IsSubclassOf(typeof(PrimaryKey)), Is.True);
    }

    [Test]
    public void Should_Construct_With_Valid_Values()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_user.Email, Is.EqualTo(Email));
            Assert.That(_user.Password, Is.EqualTo(Password));
            Assert.That(_user.Firstname, Is.EqualTo(Firstname));
            Assert.That(_user.Lastname, Is.EqualTo(Lastname));
        });
    }

    [TestCase("", "", "firstname", "lastname")]
    [TestCase("test@email.com", "", "firstname", "lastname")]
    [TestCase("", "password", "firstname", "lastname")]
    public void Should_Throw_On_Construct_With_Invalid_Values(
        string email,
        string password,
        string firstname,
        string lastname
    )
    {
        Assert.Throws<ArgumentException>(() => new User(email, password, firstname, lastname));
    }

    [TestCase("setEmail@email.com")]
    public void Should_Set_Email_Correctly(string email)
    {
        _user.Email = email;

        Assert.That(_user.Email, Is.EqualTo(email));
    }

    [TestCase("")]
    [TestCase("abc")]
    [TestCase("abc@")]
    [TestCase("@")]
    [TestCase("@test")]
    [TestCase("test.")]
    [TestCase(".")]
    [TestCase("test.com")]
    [TestCase(".com")]
    [TestCase("abc@test")]
    [TestCase("abc@test.")]
    [TestCase("@test.com")]
    public void Should_Throw_For_Invalid_Email(string email)
    {
        Assert.Throws<ArgumentException>(() => _user.Email = email);
    }

    [TestCase("setPassword")]
    public void Should_Set_Password_Correctly(string password)
    {
        _user.Password = password;

        Assert.That(_user.Password, Is.EqualTo(password));
    }

    [TestCase("")]
    [TestCase("abc")]
    [TestCase("123")]
    [TestCase("/*-")]
    [TestCase("abc123")]
    [TestCase("123/*-")]
    public void Should_Throw_For_Invalid_Password(string password)
    {
        Assert.Throws<ArgumentException>(() => _user.Password = password);
    }
}

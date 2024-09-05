using Entities.Abstract;

namespace Entities.UnitTests;

public class CityTest
{
    private City _city = null!;
    private const string Name = "Name";
    private const string PostalCode = "PostalCode";

    [SetUp]
    public void Setup()
    {
        _city = new City(Name, PostalCode);
    }

    [Test]
    public void Should_Inherit_From_PrimaryKey()
    {
        Assert.That(typeof(City).IsSubclassOf(typeof(PrimaryKey)), Is.True);
    }

    [Test]
    public void Should_Construct_With_Valid_Values()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_city.Name, Is.EqualTo(Name));
            Assert.That(_city.PostalCode, Is.EqualTo(PostalCode));
        });
    }

    public void Should_Throw_On_Construct_With_Invalid_Values(
        string name,
        string postalCode,
        Country country
    )
    {
        Assert.Throws<ArgumentException>(() => new City(name, postalCode));
    }

    [TestCase("setName")]
    public void Should_Set_Name_Correctly(string name)
    {
        _city.Name = name;

        Assert.That(_city.Name, Is.EqualTo(name));
    }

    [TestCase("")]
    public void Should_Throw_For_Invalid_Name(string name)
    {
        Assert.Throws<ArgumentException>(() => _city.Name = name);
    }

    [TestCase("setPostalCode")]
    public void Should_Set_PostalCode_Correctly(string name)
    {
        _city.PostalCode = name;

        Assert.That(_city.PostalCode, Is.EqualTo(name));
    }

    [TestCase("")]
    public void Should_Throw_For_Invalid_PostalCode(string name)
    {
        Assert.Throws<ArgumentException>(() => _city.PostalCode = name);
    }
}

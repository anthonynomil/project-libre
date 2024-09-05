using Entities.Abstract;

namespace Entities.UnitTests;

public class CountryTest
{
    private Country _country = null!;
    private const string Name = "Name";
    private const string FlagSvg = "FlagSvg";

    [SetUp]
    public void Setup()
    {
        _country = new Country(Name, FlagSvg);
    }

    [Test]
    public void Should_Inherit_From_PrimaryKey()
    {
        Assert.That(typeof(Country).IsSubclassOf(typeof(PrimaryKey)), Is.True);
    }

    [TestCase(Name)]
    public void Should_Construct_With_Valid_Values(string name)
    {
        Assert.That(_country.Name, Is.EqualTo(name));
    }

    [TestCase("", "")]
    public void Should_Throw_On_Construct_With_Invalid_Values(string name, string flagSvg)
    {
        Assert.Throws<ArgumentException>(() => new Country(name, flagSvg));
    }

    [TestCase("setName")]
    public void Should_Set_Name_Correctly(string name)
    {
        _country.Name = name;

        Assert.That(_country.Name, Is.EqualTo(name));
    }

    [TestCase("")]
    public void Should_Throw_For_Invalid_Name(string name)
    {
        Assert.Throws<ArgumentException>(() => _country.Name = name);
    }
}

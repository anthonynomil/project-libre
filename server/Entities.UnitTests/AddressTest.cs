using Entities.Abstract;

namespace Entities.UnitTests;

public class AddressTest
{
    private Address _address = null!;
    private readonly City _city = new("City", "PostalCode");
    private const int Number = 0;
    private const string NumberComplement = "NumberComplement";
    private const string Road = "Road";

    [SetUp]
    public void Setup()
    {
        _address = new Address(_city, Number, NumberComplement, Road);
    }

    [Test]
    public void Should_Inherit_From_PrimaryKey()
    {
        Assert.That(typeof(Address).IsSubclassOf(typeof(PrimaryKey)), Is.True);
    }

    [Test]
    public void Should_Construct_With_Valid_Values()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_address.City, Is.EqualTo(_city));
            Assert.That(_address.Number, Is.EqualTo(Number));
            Assert.That(_address.NumberComplement, Is.EqualTo(NumberComplement));
            Assert.That(_address.Road, Is.EqualTo(Road));
        });
    }

    [TestCase(1, "", "")]
    [TestCase(1, "numberComplement", "")]
    [TestCase(1, "", "road")]
    public void Should_Throw_On_Construct_With_Invalid_Values(
        int number,
        string numberComplement,
        string road
    )
    {
        Assert.Throws<ArgumentException>(() => new Address(_city, number, numberComplement, road));
    }

    [Test]
    public void Should_Set_City_Correctly()
    {
        var city = new City("setCity", "setPostalCode");

        _address.City = city;

        Assert.That(_address.City, Is.EqualTo(city));
    }

    [TestCase(1)]
    public void Should_Set_Number_Correctly(int number)
    {
        _address.Number = number;

        Assert.That(_address.Number, Is.EqualTo(number));
    }

    [TestCase(-1)]
    public void Should_Throw_For_Invalid_Number(int number)
    {
        Assert.Throws<ArgumentException>(() => _address.Number = number);
    }

    [TestCase("setNumberComplement")]
    public void Should_Set_NumberComplement_Correctly(string numberComplement)
    {
        _address.NumberComplement = numberComplement;

        Assert.That(_address.NumberComplement, Is.EqualTo(numberComplement));
    }

    [TestCase("")]
    public void Should_Throw_For_Invalid_NumberComplement(string numberComplement)
    {
        Assert.Throws<ArgumentException>(() => _address.NumberComplement = numberComplement);
    }

    [TestCase("setRoad")]
    public void Should_Set_Road_Correctly(string road)
    {
        _address.Road = road;

        Assert.That(_address.Road, Is.EqualTo(road));
    }

    [TestCase("")]
    public void Should_Throw_For_Invalid_Road(string road)
    {
        Assert.Throws<ArgumentException>(() => _address.Road = road);
    }
}

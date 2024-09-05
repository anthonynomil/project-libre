using Entities.Abstract;

namespace Entities.UnitTests;

internal class Concrete : PrimaryKey;

public class PrimaryKeyTest
{
    private Concrete _concrete = null!;
    private const int Id = 0;

    [SetUp]
    public void Setup()
    {
        _concrete = new Concrete();
    }

    [TestCase(Id)]
    public void Should_Construct_With_Valid_Values(int id)
    {
        Assert.That(_concrete.Id, Is.EqualTo(id));
    }
}

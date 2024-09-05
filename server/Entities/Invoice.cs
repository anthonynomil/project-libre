using Entities.Abstract;
using Entities.Helper;

namespace Entities;

public class Invoice : PrimaryKey, ITimestampedEntity
{
    private string _designation = null!;

    private Invoice() { }

    public Invoice(string designation)
    {
        if (string.IsNullOrEmpty(designation))
            throw new ArgumentException($"Parameter {nameof(designation)} can't be null or empty.");

        Designation = designation;
    }

    public string Designation
    {
        get => _designation;
        set
        {
            EntityValidator.RequiredString(value, nameof(Designation));
            _designation = value;
        }
    }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

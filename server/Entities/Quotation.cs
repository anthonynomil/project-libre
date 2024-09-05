using Entities.Abstract;

namespace Entities;

public class Quotation : PrimaryKey, ITimestampedEntity
{
    private Quotation() { }

    public Quotation(string designation) { }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}

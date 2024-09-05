using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Configuration;

internal static class TimestampTypes
{
    private const string MysqlMinimumTimestamp = "'1970-01-01 00:00:01'";

    public static IEnumerable<EntityEntry<ITimestampedEntity>> GetAddedAndModifiedEntries(
        this ChangeTracker changeTracker
    ) => changeTracker.Entries<ITimestampedEntity>().Where(HasAddedOrModifiedState);

    public static void SetTimestampFields(
        this IEnumerable<EntityEntry<ITimestampedEntity>> timestampedEntities
    )
    {
        foreach (var entry in timestampedEntities)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(entry.State),
                        entry.State,
                        $"{nameof(SetTimestampFields)} is not meant to handle entities of {entry.State} state."
                    );
            }
        }
    }

    public static IEnumerable<IMutableEntityType> GetTimestampedEntityTypes(
        ModelBuilder modelBuilder
    ) => modelBuilder.Model.GetEntityTypes().Where(ImplementsITimestampedEntity);

    public static void SetDefaultToMysqlMinimumTimestamp(
        this IEnumerable<IMutableProperty> enumerable
    )
    {
        foreach (var property in enumerable)
        {
            property.SetDefaultValueSql(MysqlMinimumTimestamp);
        }
    }

    public static IEnumerable<IMutableProperty> GetCreatedAtProperties(
        this IEnumerable<IMutableEntityType> mutableEntityTypes
    ) => mutableEntityTypes.SelectMany(t => t.GetProperties()).Where(IsCreatedAtProperty);

    private static bool ImplementsITimestampedEntity(IReadOnlyTypeBase t) =>
        t.ClrType.GetInterface(nameof(ITimestampedEntity)) != null;

    private static bool IsCreatedAtProperty(IReadOnlyPropertyBase p) =>
        p.Name == nameof(ITimestampedEntity.CreatedAt);

    private static bool HasAddedOrModifiedState(EntityEntry e) =>
        e.State is EntityState.Added or EntityState.Modified;
}

using Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

// TODO Tristan : https://learn.microsoft.com/en-us/ef/core/performance/advanced-performance-topics?tabs=with-di%2Cexpression-api-with-constant#dbcontext-pooling
public class ProjetLibreContext(DbContextOptions<ProjetLibreContext> options) : DbContext(options)
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(true, cancellationToken);
    }

    // https://code-maze.com/csharp-map-dateonly-timeonly-types-to-sql/
    protected override void ConfigureConventions(
        ModelConfigurationBuilder modelConfigurationBuilder
    )
    {
        modelConfigurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>();
        base.ConfigureConventions(modelConfigurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        PrimaryKeyTypes.GetPrimaryKeyEntityTypes().AddToModelBuilder(modelBuilder);
        TimestampTypes
            .GetTimestampedEntityTypes(modelBuilder)
            .GetCreatedAtProperties()
            .SetDefaultToMysqlMinimumTimestamp();
        base.OnModelCreating(modelBuilder);
    }

    private void OnBeforeSaving()
    {
        ChangeTracker.DetectChanges();
        ChangeTracker.GetAddedAndModifiedEntries().SetTimestampFields();
    }
}

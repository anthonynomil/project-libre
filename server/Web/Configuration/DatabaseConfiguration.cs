using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Web.Configuration;

internal static class DatabaseConfiguration
{
    private const string ConnectionString = "DefaultConnection";

    public static void SetupDatabase(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.ValidateDatabaseConfiguration();
        webApplicationBuilder.AddDbContext();
    }

    private static void ValidateDatabaseConfiguration(
        this WebApplicationBuilder webApplicationBuilder
    )
    {
        if (
            string.IsNullOrWhiteSpace(
                webApplicationBuilder.Configuration.GetConnectionString(ConnectionString)
            )
        )
            throw new InvalidConfigurationException(
                $"No {ConnectionString} was provided as {nameof(ConnectionString)} in the configuration."
            );
    }

    private static void AddDbContext(this WebApplicationBuilder configuration)
    {
        configuration.Services.AddDbContext<ProjetLibreContext>(optionsBuilder =>
        {
            optionsBuilder.UseMySQL(
                configuration.Configuration.GetConnectionString(ConnectionString)!
            );
        });
    }
}

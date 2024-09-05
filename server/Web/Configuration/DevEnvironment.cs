using Microsoft.IdentityModel.Protocols.Configuration;

namespace Web.Configuration;

internal static class DevEnvironment
{
    private const string PublishedApplicationName = "PublishedApplicationName";

    public static void SetupDevEnvironment(this WebApplication app)
    {
        app.ValidateConfiguration();
        app.SetupCorsPolicies();
        app.SetupSwagger();
    }

    private static void ValidateConfiguration(this WebApplication app)
    {
        if (string.IsNullOrWhiteSpace(app.Configuration[$"{PublishedApplicationName}"]))
            throw new InvalidConfigurationException(
                $"No {PublishedApplicationName} was provided in the configuration."
            );
    }

    private static void SetupCorsPolicies(this IApplicationBuilder webApplication)
    {
        webApplication.UseCors(
            options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
        );
    }

    private static void SetupSwagger(this WebApplication webApplication)
    {
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                webApplication.Configuration[PublishedApplicationName] + "API"
            );
            options.RoutePrefix = "docs";
        });
    }
}

namespace Web.Configuration;

internal static class DotNetServices
{
    public static void SetupDotNetServices(this IHostApplicationBuilder app)
    {
        app.Services.AddControllers();
        app.Services.AddEndpointsApiExplorer();
    }
}

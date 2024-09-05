using Application.Interface;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Web.Configuration;

internal static class Initialization
{
    public static async Task InitializationRoutine(this IServiceScope serviceScope)
    {
        await ExecuteMigration(serviceScope);
        await RefreshExternalData(serviceScope);
    }

    private static async Task ExecuteMigration(IServiceScope serviceScope)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<ProjetLibreContext>();
        await context.Database.MigrateAsync();
    }

    private static async Task RefreshExternalData(IServiceScope serviceScope)
    {
        var init =
            serviceScope.ServiceProvider.GetRequiredService<IInitializationApplicationService>();
        await init.Init();
    }
}

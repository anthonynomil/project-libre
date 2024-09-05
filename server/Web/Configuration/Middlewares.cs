using Infrastructure.Middleware;

namespace Web.Configuration;

internal static class Middlewares
{
    public static void SetupMiddlewares(this WebApplication webApplication)
    {
        webApplication.UseMiddleware<LoggingMiddleware>();

        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseMiddleware<DevExceptionHandlingMiddleware>();
        }
        else
        {
            webApplication.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        webApplication.UseAuthentication();
        webApplication.UseHttpsRedirection();
        webApplication.UseRequestLocalization();
        webApplication.UseRouting();
        webApplication.UseAuthorization();
        webApplication.MapControllers();
    }
}

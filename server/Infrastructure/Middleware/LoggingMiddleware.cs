using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middleware;

public sealed class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(
            "{DateTime} - Incoming request: {Method} {Path}",
            DateTimeOffset.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"),
            context.Request.Method,
            context.Request.Path
        );

        await _next(context);

        _logger.LogInformation(
            "{DateTime} - Outgoing response: Status Code {StatusCode}",
            DateTimeOffset.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"),
            context.Response.StatusCode
        );
    }
}

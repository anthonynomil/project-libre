using System.Data.SqlTypes;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    protected ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    protected virtual object PrepareResponse(Exception e)
    {
        return new { message = e.Message };
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var statusCode = GetStatusCodeFromException(e);
        context.Response.StatusCode = (int)statusCode;
        var response = PrepareResponse(e);
        await SetResponseAsync(context, response);
    }

    private static HttpStatusCode GetStatusCodeFromException(Exception e)
    {
        return ExceptionCodeProvider.TryGetStatusCode(e, out var statusCode)
            ? statusCode
            : HttpStatusCode.InternalServerError;
    }

    private static async Task SetResponseAsync(HttpContext context, object response)
    {
        var payload = JsonSerializer.Serialize(response);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(payload);
    }

    private static class ExceptionCodeProvider
    {
        private static readonly Dictionary<Type, HttpStatusCode> ExceptionToStatusCode =
            new() { { typeof(SqlNullValueException), HttpStatusCode.NotFound } };

        public static bool TryGetStatusCode(Exception exception, out HttpStatusCode statusCode)
        {
            return ExceptionToStatusCode.TryGetValue(exception.GetType(), out statusCode);
        }
    }
}

public sealed class DevExceptionHandlingMiddleware(RequestDelegate next)
    : ExceptionHandlingMiddleware(next)
{
    protected override object PrepareResponse(Exception e)
    {
        return new { message = e.Message, stackTrace = e.StackTrace };
    }
}

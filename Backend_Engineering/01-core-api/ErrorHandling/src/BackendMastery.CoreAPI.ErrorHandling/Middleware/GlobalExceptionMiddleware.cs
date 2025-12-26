using System.Net;
using System.Text.Json;
using BackendMastery.CoreAPI.ErrorHandling.Exceptions;

namespace BackendMastery.CoreAPI.ErrorHandling.Middleware;

/// <summary>
/// Centralized exception handling middleware.
/// </summary>
/// <remarks>
/// Intuition:
/// - Controllers should not handle cross-cutting concerns
/// - One place to log, translate, and respond
///
/// Use case:
/// - Consistent error responses
/// - Centralized alerting
/// <para><b>Catch → Log → Handle → Retry / Fail</b></para>
/// </remarks>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static async Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/problem+json";

        var statusCode = ex switch
        {
            ResourceNotFoundException => HttpStatusCode.NotFound,
            ArgumentException => HttpStatusCode.BadRequest,
            ExternalServiceException => HttpStatusCode.ServiceUnavailable,
            _ => HttpStatusCode.InternalServerError
        };

        context.Response.StatusCode = (int)statusCode;

        var problem = new
        {
            title = statusCode.ToString(),
            status = (int)statusCode,
            detail = ex.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }
}
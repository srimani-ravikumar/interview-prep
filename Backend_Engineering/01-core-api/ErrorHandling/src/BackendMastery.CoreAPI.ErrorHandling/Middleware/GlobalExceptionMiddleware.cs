using BackendMastery.CoreAPI.ErrorHandling.Exceptions;
using System.Net;
using System.Text.Json;

namespace BackendMastery.CoreAPI.ErrorHandling.Middleware;

/// <summary>
/// Centralized exception handling middleware.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Controllers should not handle cross-cutting concerns
/// - One place to log, translate, and respond
///</para>
///<para>
/// Use case:
/// - Consistent error responses
/// - Centralized alerting
/// </para>
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

        // Utlizing Anonymous type feature in C# to avoid loading unneccessary types onto the heap memory
        // Structured response for the client to take next steps
        var problem = new
        {
            timeStamp = DateTime.Now,
            status = (int)statusCode,
            title = statusCode.ToString(),
            message = ex.Message,
            path = context.Request.Path
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }
}
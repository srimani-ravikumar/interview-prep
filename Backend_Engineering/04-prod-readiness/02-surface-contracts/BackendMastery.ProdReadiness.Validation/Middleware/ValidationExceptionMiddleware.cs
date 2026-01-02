using BackendMastery.ProdReadiness.Validation.Contracts.Responses;
using BackendMastery.ProdReadiness.Validation.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Validation.Middleware;

/// <summary>
/// INTUITION:
/// Validation failures are expected errors, not exceptions.
///
/// USE CASE:
/// Converts framework-level validation issues into stable API errors.
///
/// FAILURE MODE:
/// Without this middleware, errors leak as framework responses.
/// </summary>
public sealed class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.HasJsonContentType())
        {
            await _next(context);
            return;
        }

        context.Request.EnableBuffering();
        await _next(context);

        if (context.Response.StatusCode != StatusCodes.Status400BadRequest)
            return;
    }
}
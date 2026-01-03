using BackendMastery.ApiProduction.EnvironmentConfiguration.Services;

namespace BackendMastery.ApiProduction.EnvironmentConfiguration.Middleware;

/// <summary>
/// WHY:
/// Enforces environment constraints at the boundary.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents unsafe endpoints from being exposed in production.
///
/// WHEN TO USE:
/// When behavior must be blocked entirely in certain environments.
///
/// WHAT BREAKS IF MISUSED:
/// Missing guards expose internal diagnostics publicly.
/// </summary>
public sealed class EnvironmentGuardMiddleware
{
    private readonly RequestDelegate _next;

    public EnvironmentGuardMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        EnvironmentBehaviorService behaviorService)
    {
        if (context.Request.Path.StartsWithSegments("/diagnostics")
            && !behaviorService.IsDiagnosticsAllowed())
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        await _next(context);
    }
}
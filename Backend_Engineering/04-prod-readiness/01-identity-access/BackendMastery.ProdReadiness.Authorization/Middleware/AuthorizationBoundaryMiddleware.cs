using BackendMastery.ProdReadiness.Authorization.Infrastructure.Identity;

namespace BackendMastery.ProdReadiness.Authorization.Middleware;

/// WHY: Establishes authorization boundary.
/// USE CASE: Ensures authorization failures are handled consistently.
/// WARNING: Bypassing this risks privilege escalation.
public sealed class AuthorizationBoundaryMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationBoundaryMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Identity is assumed to be injected by authentication layer
        if (!context.Items.TryGetValue("Identity", out var identityObj) ||
            identityObj is not AuthenticatedIdentity)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }

        await _next(context);
    }
}
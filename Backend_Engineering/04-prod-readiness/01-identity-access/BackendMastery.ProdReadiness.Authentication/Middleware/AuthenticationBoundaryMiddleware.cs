using BackendMastery.ProdReadiness.Authentication.Infrastructure.ApiKeys;
using BackendMastery.ProdReadiness.Authentication.Infrastructure.Identity;
using BackendMastery.ProdReadiness.Authentication.Infrastructure.Jwt;
using System.Security.Claims;

namespace BackendMastery.ProdReadiness.Authentication.Middleware;

/// WHY: This middleware is the system’s authentication boundary.
/// USE CASE: Ensures all requests carry a verified identity.
/// WARNING: Bypassing this bypasses all security guarantees.
public sealed class AuthenticationBoundaryMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationBoundaryMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        JwtTokenValidator jwtValidator,
        ApiKeyValidator apiKeyValidator)
    {
        AuthenticatedIdentity? identity = null;

        // JWT-based authentication
        if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            var authHeaderValue = authHeader.ToString();

            if (authHeaderValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeaderValue.Substring("Bearer ".Length);
                var principal = jwtValidator.Validate(token);

                identity = new AuthenticatedIdentity(
                    principal.FindFirstValue(ClaimTypes.NameIdentifier)!,
                    "JWT",
                    principal.Claims.ToDictionary(c => c.Type, c => c.Value));
            }
        }
        // API Key authentication
        else if (context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey) &&
                 apiKeyValidator.IsValid(apiKey.ToString()))
        {
            identity = new AuthenticatedIdentity(
                "api-client",
                "API_KEY",
                new Dictionary<string, string>());
        }

        if (identity is null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        context.Items["Identity"] = identity;
        await _next(context);
    }
}
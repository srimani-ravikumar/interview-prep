using BackendMastery.ProdReadiness.Authorization.Infrastructure.Identity;

namespace BackendMastery.ProdReadiness.Authorization.Middleware;

/// WHY: Simulates an authenticated identity for authorization testing.
/// USE CASE: Local development and concept demonstration.
/// WARNING: MUST NEVER be used in production.
public sealed class FakeAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public FakeAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Simulate identity injected by authentication layer
        context.Items["Identity"] = new AuthenticatedIdentity(
            subject: "alice",
            claims: new Dictionary<string, string>
            {
                ["role"] = "user",
                ["department"] = "sales"
            });

        await _next(context);
    }
}
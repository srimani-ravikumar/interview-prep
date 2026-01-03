using BackendMastery.ProdReadiness.Idempotency.Infrastructure;

namespace BackendMastery.ProdReadiness.Idempotency.Middleware;

/// <summary>
/// Enforces idempotency for write requests.
///
/// WHY THIS EXISTS:
/// Idempotency must be applied BEFORE business logic runs.
///
/// WHAT PROBLEM THIS SOLVES:
/// Guarantees that duplicate requests do not
/// repeat side effects.
///
/// WHEN TO USE:
/// All retry-safe POST/PUT endpoints.
///
/// WHAT BREAKS IF MISUSED:
/// Applying idempotency too late allows duplication.
/// </summary>
public sealed class IdempotencyMiddleware
{
    private readonly RequestDelegate _next;

    public IdempotencyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        InMemoryIdempotencyStore store)
    {
        if (!context.Request.Headers.TryGetValue(
            "Idempotency-Key", out var key))
        {
            await _next(context);
            return;
        }

        if (store.TryGet(key!, out var cachedResult))
        {
            // Safe replay: return previous result
            context.Response.StatusCode = 200;
            await context.Response.WriteAsJsonAsync(cachedResult);
            return;
        }

        // Capture response for first execution
        var originalBody = context.Response.Body;
        using var buffer = new MemoryStream();
        context.Response.Body = buffer;

        await _next(context);

        buffer.Seek(0, SeekOrigin.Begin);
        var result = await new StreamReader(buffer).ReadToEndAsync();

        store.Store(key!, result);

        buffer.Seek(0, SeekOrigin.Begin);
        await buffer.CopyToAsync(originalBody);
    }
}
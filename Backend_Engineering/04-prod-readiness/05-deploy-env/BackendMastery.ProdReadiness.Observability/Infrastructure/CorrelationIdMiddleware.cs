namespace BackendMastery.ProdReadiness.Observability.Infrastructure;

/// <summary>
/// Establishes a correlation ID for every incoming request.
///
/// WHY THIS EXISTS:
/// In production, logs without correlation
/// are isolated facts with no story.
///
/// WHAT PROBLEM THIS SOLVES:
/// Enables request tracing across layers
/// and across services.
///
/// WHEN TO USE:
/// Every customer-facing API.
///
/// WHAT BREAKS IF MISUSED:
/// Incidents become untraceable.
/// Logs become noise.
/// </summary>
public sealed class CorrelationIdMiddleware
{
    private const string HeaderName = "X-Correlation-Id";
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    public CorrelationIdMiddleware(
        RequestDelegate next,
        ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId =
            context.Request.Headers.TryGetValue(HeaderName, out var value)
                ? value.ToString()
                : Guid.NewGuid().ToString();

        context.Items[HeaderName] = correlationId;
        context.Response.Headers[HeaderName] = correlationId;

        using (_logger.BeginScope(new Dictionary<string, object>
        {
            ["CorrelationId"] = correlationId
        }))
        {
            await _next(context);
        }
    }
}
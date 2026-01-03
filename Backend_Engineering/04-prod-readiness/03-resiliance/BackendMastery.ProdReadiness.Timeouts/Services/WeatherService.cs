using BackendMastery.ProdReadiness.Timeouts.Infrastructure;

namespace BackendMastery.ProdReadiness.Timeouts.Services;

/// <summary>
/// Coordinates business logic with external dependencies.
///
/// WHY THIS EXISTS:
/// Timeouts must be enforced at dependency boundaries,
/// not in controllers.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents HTTP layer from owning resilience concerns.
///
/// WHEN TO USE:
/// Always enforce resilience rules in services.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers become bloated and untestable.
/// </summary>
public sealed class WeatherService : IWeatherService
{
    private readonly ExternalWeatherClient _client;

    public WeatherService(ExternalWeatherClient client)
    {
        _client = client;
    }

    public async Task<string> GetWeatherAsync(
        CancellationToken cancellationToken)
    {
        // No retry, no fallback — fail fast
        return await _client.GetWeatherAsync(cancellationToken);
    }
}
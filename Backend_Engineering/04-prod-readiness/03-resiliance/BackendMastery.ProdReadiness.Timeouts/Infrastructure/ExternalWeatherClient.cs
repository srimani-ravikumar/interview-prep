using BackendMastery.ProdReadiness.Timeouts.Configuration;

namespace BackendMastery.ProdReadiness.Timeouts.Infrastructure;

/// <summary>
/// Simulates a remote HTTP dependency.
///
/// WHY THIS EXISTS:
/// All production systems depend on things they do not control.
///
/// WHAT PROBLEM THIS SOLVES:
/// Demonstrates how unbounded external calls
/// can stall the entire application.
///
/// WHEN TO USE:
/// Any time you call:
/// - HTTP services
/// - Databases
/// - Message brokers
///
/// WHAT BREAKS IF MISUSED:
/// No timeout → thread starvation and cascading failure.
/// </summary>
public sealed class ExternalWeatherClient
{
    private readonly TimeSpan _timeout;

    public ExternalWeatherClient(TimeoutOptions options)
    {
        _timeout = TimeSpan.FromMilliseconds(
            options.ExternalWeatherApiMilliseconds);
    }

    public async Task<string> GetWeatherAsync(
        CancellationToken cancellationToken)
    {
        // Combine caller cancellation with timeout boundary
        using var timeoutCts = CancellationTokenSource
            .CreateLinkedTokenSource(cancellationToken);

        timeoutCts.CancelAfter(_timeout);

        try
        {
            // Simulate unpredictable latency
            await Task.Delay(
                TimeSpan.FromSeconds(5),
                timeoutCts.Token);

            return "Sunny";
        }
        catch (OperationCanceledException)
        {
            // Timeout is not an error in logic —
            // it is a protective failure.
            throw new TimeoutException(
                "External weather service exceeded timeout budget.");
        }
    }
}
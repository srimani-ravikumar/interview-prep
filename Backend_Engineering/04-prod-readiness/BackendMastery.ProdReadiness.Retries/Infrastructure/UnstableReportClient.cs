namespace BackendMastery.ProdReadiness.Retries.Infrastructure;

/// <summary>
/// Simulates a flaky external dependency.
///
/// WHY THIS EXISTS:
/// Many production dependencies fail intermittently,
/// not permanently.
///
/// WHAT PROBLEM THIS SOLVES:
/// Allows us to reason about transient failures.
///
/// WHEN TO USE:
/// Represents HTTP APIs, queues, or services under load.
///
/// WHAT BREAKS IF MISUSED:
/// Assuming failures are rare leads to fragile systems.
/// </summary>
public sealed class UnstableReportClient
{
    private static readonly Random _random = new();

    public async Task<string> FetchReportAsync(
        CancellationToken cancellationToken)
    {
        await Task.Delay(300, cancellationToken);

        // Simulate transient failure ~50% of the time
        if (_random.NextDouble() < 0.5)
        {
            throw new TimeoutException("Transient dependency timeout.");
        }

        return "Monthly Report Data";
    }
}
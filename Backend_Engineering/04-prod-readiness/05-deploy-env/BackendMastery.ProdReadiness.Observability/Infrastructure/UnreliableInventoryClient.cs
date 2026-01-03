namespace BackendMastery.ProdReadiness.Observability.Infrastructure;

/// <summary>
/// Simulates an unstable inventory dependency.
///
/// WHY THIS EXISTS:
/// Observability is useless without failures.
///
/// WHAT PROBLEM THIS SOLVES:
/// Demonstrates failure visibility in logs.
///
/// WHAT BREAKS IF MISUSED:
/// Assuming dependencies fail cleanly.
/// </summary>
public sealed class UnreliableInventoryClient
{
    private static readonly Random _random = new();

    public async Task ReserveAsync(
        string orderId,
        CancellationToken cancellationToken)
    {
        await Task.Delay(200, cancellationToken);

        if (_random.NextDouble() < 0.4)
        {
            throw new Exception("Inventory reservation failed.");
        }
    }
}
namespace BackendMastery.ProdReadiness.Fallbacks.Infrastructure;

/// <summary>
/// Simulates external pricing service.
///
/// WHY THIS EXISTS:
/// Pricing services often fail under load
/// or during deployments.
///
/// WHAT BREAKS IF MISUSED:
/// Treating pricing as optional is a business bug.
/// </summary>
public sealed class PricingClient
{
    private static readonly Random _random = new();

    public async Task<decimal> GetPriceAsync(
        string productId,
        CancellationToken cancellationToken)
    {
        await Task.Delay(300, cancellationToken);

        if (_random.NextDouble() < 0.5)
            throw new Exception("Pricing service unavailable.");

        return 499.99m;
    }
}
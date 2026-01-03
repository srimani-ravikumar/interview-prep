namespace BackendMastery.ProdReadiness.CircuitBreakers.Infrastructure;

/// <summary>
/// Simulates an unstable external payment gateway.
///
/// WHY THIS EXISTS:
/// Many real-world dependencies fail repeatedly
/// before fully recovering.
///
/// WHAT BREAKS IF MISUSED:
/// Assuming dependencies fail fast leads to bad design.
/// </summary>
public sealed class FlakyPaymentGateway
{
    private static readonly Random _random = new();

    public async Task<string> ProcessAsync(
        CancellationToken cancellationToken)
    {
        await Task.Delay(200, cancellationToken);

        if (_random.NextDouble() < 0.7)
        {
            throw new Exception("Payment gateway failure.");
        }

        return "PAYMENT_ACCEPTED";
    }
}
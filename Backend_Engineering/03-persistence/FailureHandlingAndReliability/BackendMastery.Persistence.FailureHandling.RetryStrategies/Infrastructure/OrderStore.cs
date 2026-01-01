using BackendMastery.Persistence.FailureHandling.RetryStrategies.Domain;

namespace BackendMastery.Persistence.FailureHandling.RetryStrategies.Infrastructure;

/// <summary>
/// Simulates an order persistence layer.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Not all failures are equal
///
/// FAILURE TYPES:
/// - Transient → retry MAY succeed
/// - Permanent → retry will NEVER succeed
///
/// KEY RULE:
/// ❗ Retry only transient failures
/// </remarks>
public class OrderStore
{
    public void Save(Order order)
    {
        int outcome = Random.Shared.Next(0, 5);

        if (outcome == 0)
            throw new TimeoutException("Transient DB timeout");

        if (outcome == 1)
            throw new InvalidOperationException("Permanent constraint violation");

        Console.WriteLine($"Order persisted: {order.OrderId}");
    }
}
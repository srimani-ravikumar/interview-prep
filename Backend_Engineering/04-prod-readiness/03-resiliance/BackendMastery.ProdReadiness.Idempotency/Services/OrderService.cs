namespace BackendMastery.ProdReadiness.Idempotency.Services;

/// <summary>
/// Handles order creation.
///
/// WHY THIS EXISTS:
/// Encapsulates side effects that must be protected
/// by idempotency guarantees.
///
/// WHAT BREAKS IF MISUSED:
/// Retrying this logic without idempotency
/// causes duplicate orders.
/// </summary>
public sealed class OrderService : IOrderService
{
    public Task<object> CreateOrderAsync(
        object request,
        CancellationToken cancellationToken)
    {
        // Simulate irreversible side effect
        var response = new
        {
            OrderId = Guid.NewGuid(),
            Status = "CREATED"
        };

        return Task.FromResult<object>(response);
    }
}
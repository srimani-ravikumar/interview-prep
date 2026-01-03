namespace BackendMastery.ProdReadiness.Idempotency.Services;

/// <summary>
/// Defines order creation behavior.
///
/// WHY THIS EXISTS:
/// Business logic must be isolated from HTTP concerns.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers owning business logic become fragile.
/// </summary>
public interface IOrderService
{
    Task<object> CreateOrderAsync(
        object request,
        CancellationToken cancellationToken);
}
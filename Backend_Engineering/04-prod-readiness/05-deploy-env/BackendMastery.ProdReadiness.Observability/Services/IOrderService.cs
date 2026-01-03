using BackendMastery.ProdReadiness.Observability.Contracts;

namespace BackendMastery.ProdReadiness.Observability.Services;

/// <summary>
/// Order processing contract.
///
/// WHY THIS EXISTS:
/// Observability should not leak
/// into controllers.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers owning business logic.
/// </summary>
public interface IOrderService
{
    Task<OrderResponse> CreateAsync(
        CancellationToken cancellationToken);
}
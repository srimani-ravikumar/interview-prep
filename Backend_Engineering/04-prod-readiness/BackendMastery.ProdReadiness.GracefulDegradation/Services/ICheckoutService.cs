using BackendMastery.ProdReadiness.GracefulDegradation.Contracts;

namespace BackendMastery.ProdReadiness.GracefulDegradation.Services;

/// <summary>
/// Checkout contract.
///
/// WHY THIS EXISTS:
/// Checkout must remain operational
/// regardless of optional feature health.
/// </summary>
public interface ICheckoutService
{
    Task<CheckoutResponse> CheckoutAsync(
        CancellationToken cancellationToken);
}
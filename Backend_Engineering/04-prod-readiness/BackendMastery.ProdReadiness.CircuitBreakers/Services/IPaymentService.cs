using BackendMastery.ProdReadiness.CircuitBreakers.Contracts;

namespace BackendMastery.ProdReadiness.CircuitBreakers.Services;

/// <summary>
/// Defines payment processing behavior.
///
/// WHY THIS EXISTS:
/// Shields controllers from infrastructure
/// and resilience concerns.
///
/// WHAT BREAKS IF MISUSED:
/// Returning primitives hides business meaning.
/// </summary>
public interface IPaymentService
{
    Task<PaymentResponse> ProcessPaymentAsync(
        CancellationToken cancellationToken);
}
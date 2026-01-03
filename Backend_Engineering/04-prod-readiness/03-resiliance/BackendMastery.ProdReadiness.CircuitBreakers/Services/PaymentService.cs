using BackendMastery.ProdReadiness.CircuitBreakers.Contracts;
using BackendMastery.ProdReadiness.CircuitBreakers.Infrastructure;

namespace BackendMastery.ProdReadiness.CircuitBreakers.Services;

/// <summary>
/// Coordinates payment processing with circuit breaker protection.
///
/// WHY THIS EXISTS:
/// Ensures repeated dependency failures
/// do not cascade through the system.
/// </summary>
public sealed class PaymentService : IPaymentService
{
    private readonly FlakyPaymentGateway _gateway;
    private readonly CircuitBreaker _breaker;

    public PaymentService(
        FlakyPaymentGateway gateway,
        CircuitBreaker breaker)
    {
        _gateway = gateway;
        _breaker = breaker;
    }

    public async Task<PaymentResponse> ProcessPaymentAsync(
        CancellationToken cancellationToken)
    {
        if (!_breaker.AllowRequest())
        {
            // Circuit is open → fail fast
            throw new InvalidOperationException(
                "Payment gateway temporarily unavailable.");
        }

        try
        {
            var result = await _gateway
                .ProcessAsync(cancellationToken);

            _breaker.RecordSuccess();

            return new PaymentResponse(
                Status: result,
                ReferenceId: Guid.NewGuid().ToString());
        }
        catch
        {
            _breaker.RecordFailure();
            throw;
        }
    }
}
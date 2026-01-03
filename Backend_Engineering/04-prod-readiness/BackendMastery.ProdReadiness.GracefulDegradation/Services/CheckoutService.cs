using BackendMastery.ProdReadiness.GracefulDegradation.Contracts;
using BackendMastery.ProdReadiness.GracefulDegradation.Infrastructure;

namespace BackendMastery.ProdReadiness.GracefulDegradation.Services;

/// <summary>
/// Handles checkout with graceful degradation.
///
/// WHY THIS EXISTS:
/// Revenue-critical paths must survive
/// even when the system is stressed.
///
/// DEGRADATION RULES:
/// - Checkout always executes
/// - Recommendations dropped under load
/// - Reviews dropped under load
///
/// WHAT BREAKS IF MISUSED:
/// Allowing optional features to block checkout
/// causes business outages.
/// </summary>
public sealed class CheckoutService : ICheckoutService
{
    private readonly FeatureGate _features;

    public CheckoutService(FeatureGate features)
    {
        _features = features;
    }

    public async Task<CheckoutResponse> CheckoutAsync(
        CancellationToken cancellationToken)
    {
        // Simulate critical checkout work
        await Task.Delay(300, cancellationToken);

        var includeRecommendations = _features.AllowRecommendations();
        var includeReviews = _features.AllowReviews();

        return new CheckoutResponse(
            OrderId: Guid.NewGuid().ToString(),
            RecommendationsIncluded: includeRecommendations,
            ReviewsIncluded: includeReviews);
    }
}
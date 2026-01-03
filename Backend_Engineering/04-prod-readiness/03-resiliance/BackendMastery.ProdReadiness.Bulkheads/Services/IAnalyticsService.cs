using BackendMastery.ProdReadiness.Bulkheads.Contracts;

namespace BackendMastery.ProdReadiness.Bulkheads.Services;

/// <summary>
/// Analytics processing contract.
///
/// WHY THIS EXISTS:
/// Analytics must not be impacted
/// by reporting slowness.
/// </summary>
public interface IAnalyticsService
{
    Task<FeatureResponse> ProcessAsync(
        CancellationToken cancellationToken);
}
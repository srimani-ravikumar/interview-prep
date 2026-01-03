using BackendMastery.ProdReadiness.Bulkheads.Contracts;
using BackendMastery.ProdReadiness.Bulkheads.Infrastructure;

namespace BackendMastery.ProdReadiness.Bulkheads.Services;

/// <summary>
/// Analytics processing service.
///
/// WHY THIS EXISTS:
/// Analytics is latency-sensitive
/// and must remain responsive.
///
/// WHAT BREAKS IF MISUSED:
/// Without isolation, analytics dies
/// due to reporting load.
/// </summary>
public sealed class AnalyticsService : IAnalyticsService
{
    private readonly Bulkhead _bulkhead;

    public AnalyticsService(Bulkhead bulkhead)
    {
        _bulkhead = bulkhead;
    }

    public async Task<FeatureResponse> ProcessAsync(
        CancellationToken cancellationToken)
    {
        await _bulkhead.ExecuteAsync(async () =>
        {
            await Task.Delay(500, cancellationToken);
        }, cancellationToken);

        return new FeatureResponse(
            Feature: "Analytics",
            Status: "COMPLETED");
    }
}
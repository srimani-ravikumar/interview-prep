using BackendMastery.ProdReadiness.Bulkheads.Contracts;
using BackendMastery.ProdReadiness.Bulkheads.Infrastructure;

namespace BackendMastery.ProdReadiness.Bulkheads.Services;

/// <summary>
/// Report generation service.
///
/// WHY THIS EXISTS:
/// Reporting is slow and risky.
/// It must not starve analytics.
///
/// WHAT BREAKS IF MISUSED:
/// Shared pools allow reporting to block everything.
/// </summary>
public sealed class ReportsService : IReportsService
{
    private readonly Bulkhead _bulkhead;

    public ReportsService(Bulkhead bulkhead)
    {
        _bulkhead = bulkhead;
    }

    public async Task<FeatureResponse> GenerateAsync(
        CancellationToken cancellationToken)
    {
        await _bulkhead.ExecuteAsync(async () =>
        {
            // Simulate slow operation
            await Task.Delay(3000, cancellationToken);
        }, cancellationToken);

        return new FeatureResponse(
            Feature: "Reports",
            Status: "COMPLETED");
    }
}
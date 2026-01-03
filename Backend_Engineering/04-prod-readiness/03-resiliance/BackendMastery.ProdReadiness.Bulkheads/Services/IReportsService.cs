using BackendMastery.ProdReadiness.Bulkheads.Contracts;

namespace BackendMastery.ProdReadiness.Bulkheads.Services;

/// <summary>
/// Report generation contract.
///
/// WHY THIS EXISTS:
/// Separates report logic from API concerns.
/// </summary>
public interface IReportsService
{
    Task<FeatureResponse> GenerateAsync(
        CancellationToken cancellationToken);
}
namespace BackendMastery.ProdReadiness.Retries.Services;

/// <summary>
/// Business contract for retrieving reports.
///
/// WHY THIS EXISTS:
/// Services own retry decisions — not controllers.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents retry logic from leaking into HTTP layer.
///
/// WHEN TO USE:
/// Whenever retry behavior is required.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers become retry-aware and fragile.
/// </summary>
public interface IReportService
{
    Task<string> GetReportAsync(CancellationToken cancellationToken);
}
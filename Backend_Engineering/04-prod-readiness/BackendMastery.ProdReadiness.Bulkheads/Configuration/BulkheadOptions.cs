namespace BackendMastery.ProdReadiness.Bulkheads.Configuration;

/// <summary>
/// Defines concurrency limits for a feature bulkhead.
///
/// WHY THIS EXISTS:
/// Bulkhead limits are business decisions
/// and must be tunable per feature.
///
/// WHAT BREAKS IF MISUSED:
/// - Too low → unnecessary throttling
/// - Too high → starvation risk
/// </summary>
public sealed class BulkheadOptions
{
    public int MaxConcurrency { get; init; }
}
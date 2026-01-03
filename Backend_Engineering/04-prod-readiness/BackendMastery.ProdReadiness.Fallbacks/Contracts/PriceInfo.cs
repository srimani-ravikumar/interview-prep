namespace BackendMastery.ProdReadiness.Fallbacks.Contracts;

/// <summary>
/// Represents pricing information.
///
/// WHY THIS EXISTS:
/// Pricing is business-critical but may be stale
/// during fallback scenarios.
///
/// WHAT BREAKS IF MISUSED:
/// Guessing prices instead of using approved sources.
/// </summary>
public sealed record PriceInfo(
    decimal Amount,
    bool IsFromCache);
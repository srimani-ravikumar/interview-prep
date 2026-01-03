namespace BackendMastery.ProdReadiness.Fallbacks.Contracts;

/// <summary>
/// Represents product details returned to clients.
///
/// WHY THIS EXISTS:
/// Clients must understand when data is degraded.
///
/// WHAT BREAKS IF MISUSED:
/// Silent fallback hides operational issues.
/// </summary>
public sealed record ProductResponse(
    string ProductId,
    PriceInfo Price,
    IReadOnlyList<string> Recommendations);
namespace BackendMastery.ProdReadiness.GracefulDegradation.Contracts;

/// <summary>
/// Represents checkout response under normal or degraded mode.
///
/// WHY THIS EXISTS:
/// Clients must understand when optional features
/// are intentionally disabled.
///
/// WHAT BREAKS IF MISUSED:
/// Silent degradation confuses users and support teams.
/// </summary>
public sealed record CheckoutResponse(
    string OrderId,
    bool RecommendationsIncluded,
    bool ReviewsIncluded);
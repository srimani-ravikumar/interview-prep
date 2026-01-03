namespace BackendMastery.ProdReadiness.Bulkheads.Contracts;

/// <summary>
/// Represents a feature response.
///
/// WHY THIS EXISTS:
/// Allows consistent error and success handling
/// across isolated features.
///
/// WHAT BREAKS IF MISUSED:
/// Returning primitives hides overload states.
/// </summary>
public sealed record FeatureResponse(
    string Feature,
    string Status);
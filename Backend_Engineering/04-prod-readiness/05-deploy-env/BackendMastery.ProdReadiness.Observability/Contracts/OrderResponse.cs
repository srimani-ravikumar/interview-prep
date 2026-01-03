namespace BackendMastery.ProdReadiness.Observability.Contracts;

/// <summary>
/// Represents order processing result.
///
/// WHY THIS EXISTS:
/// Contracts should remain clean;
/// observability lives outside payloads.
///
/// WHAT BREAKS IF MISUSED:
/// Polluting responses with debug data.
/// </summary>
public sealed record OrderResponse(
    string OrderId,
    string Status);
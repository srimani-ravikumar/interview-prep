namespace BackendMastery.ProdReadiness.Idempotency.Contracts;

/// <summary>
/// Represents the result of a successful order creation.
///
/// WHY THIS EXISTS:
/// Idempotent APIs must return the SAME response
/// for repeated identical requests.
///
/// WHAT BREAKS IF MISUSED:
/// Returning different responses breaks client trust.
/// </summary>
public sealed record OrderResponse(
    Guid OrderId,
    string Status);
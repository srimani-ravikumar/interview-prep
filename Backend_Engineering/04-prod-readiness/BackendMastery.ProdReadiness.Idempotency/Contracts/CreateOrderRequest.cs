namespace BackendMastery.ProdReadiness.Idempotency.Contracts;

/// <summary>
/// Represents a client intent to create an order.
///
/// WHY THIS EXISTS:
/// Write requests represent business intent,
/// not guaranteed execution.
///
/// WHAT BREAKS IF MISUSED:
/// Mutating fields during retries breaks idempotency.
/// </summary>
public sealed record CreateOrderRequest(
    string ProductId,
    int Quantity);
namespace BackendMastery.ProdReadiness.Validation.Contracts.Requests;

/// <summary>
/// INTUITION:
/// Request DTO represents input correctness, not business intent.
///
/// USE CASE:
/// Used only to validate request shape and basic constraints.
///
/// FAILURE MODE:
/// Skipping validation allows malformed data into deeper layers.
/// </summary>
public sealed class CreateOrderRequest
{
    public string CustomerId { get; init; } = string.Empty;

    public decimal Amount { get; init; }
}
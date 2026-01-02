namespace BackendMastery.ProdReadiness.ApiVersioning.Contracts.V2;

/// <summary>
/// INTUITION:
/// V2 introduces a breaking change.
///
/// CHANGE REASONS:
/// - Field renamed (TotalAmount → Amount)
/// - Status semantics changed
/// </summary>
public sealed class OrderResponse
{
    public Guid OrderId { get; set; }

    // Semantic change: values differ from V1
    public string State { get; set; } = string.Empty;

    // Renamed field (breaking change)
    public decimal Amount { get; set; }

    // New optional field (safe addition)
    public string? Currency { get; set; }
}
namespace BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Responses;

/// <summary>
/// INTUITION:
/// List responses should be lightweight summaries.
///
/// USE CASE:
/// Avoids over-fetching.
///
/// FAILURE MODE:
/// Returning full entities bloats responses.
/// </summary>
public sealed class OrderSummaryResponse
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
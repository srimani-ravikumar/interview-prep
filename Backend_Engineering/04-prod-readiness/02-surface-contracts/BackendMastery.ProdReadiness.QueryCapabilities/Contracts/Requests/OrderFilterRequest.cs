namespace BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Requests;

/// <summary>
/// INTUITION:
/// Filters express client intent, not database predicates.
///
/// USE CASE:
/// Allows safe narrowing of result sets.
///
/// FAILURE MODE:
/// Letting clients pass arbitrary queries leads to DB misuse.
/// </summary>
public sealed class OrderFilterRequest
{
    public string? Status { get; init; }
    public decimal? MinAmount { get; init; }
    public decimal? MaxAmount { get; init; }
}
namespace BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Requests;

/// <summary>
/// INTUITION:
/// Sorting must be explicit and limited.
///
/// USE CASE:
/// Guarantees predictable ordering.
///
/// FAILURE MODE:
/// Free-form sorting breaks indexes and paging.
/// </summary>
public sealed class OrderSortRequest
{
    public string SortBy { get; init; } = "createdAt";
    public bool Descending { get; init; } = false;
}
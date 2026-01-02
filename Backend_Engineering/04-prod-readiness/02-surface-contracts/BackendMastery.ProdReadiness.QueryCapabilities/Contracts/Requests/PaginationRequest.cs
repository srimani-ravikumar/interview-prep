namespace BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Requests;

/// <summary>
/// INTUITION:
/// Pagination limits blast radius.
///
/// USE CASE:
/// Prevents unbounded responses.
///
/// FAILURE MODE:
/// Missing pagination collapses performance at scale.
/// </summary>
public sealed class PaginationRequest
{
    public int PageSize { get; init; } = 10;
    public int PageNumber { get; init; } = 1;
}
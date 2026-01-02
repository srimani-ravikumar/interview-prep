namespace BackendMastery.ProdReadiness.QueryCapabilities.Contracts.Responses;

/// <summary>
/// INTUITION:
/// Pagination metadata is part of the contract.
///
/// USE CASE:
/// Enables clients to navigate pages safely.
///
/// FAILURE MODE:
/// Missing metadata causes duplicate or skipped data.
/// </summary>
public sealed class PagedResponse<T>
{
    public IReadOnlyCollection<T> Items { get; set; } = [];
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
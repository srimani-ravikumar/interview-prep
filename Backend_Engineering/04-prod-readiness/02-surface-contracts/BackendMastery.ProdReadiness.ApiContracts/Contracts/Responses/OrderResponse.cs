namespace BackendMastery.ProdReadiness.ApiContracts.Contracts.Responses;

/// <summary>
/// INTUITION:
/// Response DTOs define what the API PROMISES to return.
/// 
/// USE CASE:
/// Consumers bind to this shape for rendering and workflows.
/// 
/// FAILURE MODE:
/// Adding or removing fields here is a breaking change if unmanaged.
/// </summary>
public sealed class OrderResponse
{
    /// <summary>
    /// Server-generated identifier.
    /// </summary>
    public Guid OrderId { get; init; }

    /// <summary>
    /// Current lifecycle status of the order.
    /// </summary>
    public string Status { get; init; } = string.Empty;
}
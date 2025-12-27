namespace BackendMastery.StandardAPI.Api.DTOs;

/// <summary>
/// HTTP response contract for an order.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents data exposed to clients
/// - Does NOT leak domain internals
/// </remarks>
public class OrderResponse
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public bool IsPriority { get; set; }
}
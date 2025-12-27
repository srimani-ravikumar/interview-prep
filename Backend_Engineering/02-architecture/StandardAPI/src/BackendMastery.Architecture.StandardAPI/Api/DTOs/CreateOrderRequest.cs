namespace BackendMastery.StandardAPI.Api.DTOs;

/// <summary>
/// HTTP request contract for creating an order.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents client input
/// - Not a domain model
///
/// DTOs exist to:
/// - Protect domain from external change
/// - Allow independent evolution of API contracts
/// </remarks>
public class CreateOrderRequest
{
    public decimal Amount { get; set; }
}
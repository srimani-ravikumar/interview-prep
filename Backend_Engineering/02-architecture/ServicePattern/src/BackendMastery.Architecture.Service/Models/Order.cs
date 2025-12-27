namespace BackendMastery.Architecture.Service.Models;

/// <summary>
/// Input model representing an order.
/// </summary>
/// <remarks>
/// Intuition:
/// - Carries input data
/// - No business logic inside
///
/// Why?
/// - Behavior belongs in services
/// </remarks>
public class Order
{
    public decimal BaseAmount { get; set; }
    public bool IsPremiumCustomer { get; set; }
}
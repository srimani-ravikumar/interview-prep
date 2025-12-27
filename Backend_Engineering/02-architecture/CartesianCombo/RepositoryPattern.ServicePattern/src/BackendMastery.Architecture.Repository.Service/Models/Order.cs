namespace BackendMastery.Architecture.Repository.Service.Models;

/// <summary>
/// Represents an order entity.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents persisted state
/// - Can evolve with business needs
///
/// Reason to change:
/// - Order data structure changes
/// </remarks>
public class Order
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public bool IsPriority { get; set; }
}
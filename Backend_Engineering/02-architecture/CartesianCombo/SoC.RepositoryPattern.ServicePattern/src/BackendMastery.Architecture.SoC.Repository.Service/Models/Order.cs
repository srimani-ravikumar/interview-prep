namespace BackendMastery.Architecture.SoC.Repository.Service.Models;

/// <summary>
/// Represents an order domain entity.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents persisted business state
/// - Passive data holder
///
/// Reason to change:
/// - Domain model evolves
/// </remarks>
public class Order
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public bool IsPriority { get; set; }
}
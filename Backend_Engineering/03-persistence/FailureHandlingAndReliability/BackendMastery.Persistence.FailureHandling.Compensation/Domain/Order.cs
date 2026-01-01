namespace BackendMastery.Persistence.FailureHandling.Compensation.Domain;

/// <summary>
/// Represents an order spanning multiple systems.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Orders touch multiple subsystems
/// - No single transaction can cover all of them
///
/// USE CASE:
/// - Checkout flow
///
/// KEY RULE:
/// ❗ Multi-step operations must assume partial failure
/// </remarks>
public class Order
{
    public Guid OrderId { get; } = Guid.NewGuid();
    public decimal Amount { get; }

    public Order(decimal amount)
    {
        Amount = amount;
    }
}
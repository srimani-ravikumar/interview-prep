namespace BackendMastery.Persistence.FailureHandling.RetryStrategies.Domain;

/// <summary>
/// Represents an order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Order creation is irreversible
/// - Duplicate orders = financial + legal issues
///
/// USE CASE:
/// - E-commerce checkout
///
/// KEY RULE:
/// ❗ Retrying order creation blindly is dangerous
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
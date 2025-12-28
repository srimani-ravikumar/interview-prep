namespace BackendMastery.Persistence.DataModeling.EntityIdentity.Domain;

/// <summary>
/// Domain entity representing an Order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Entity identity exists from creation
/// - Attributes may change
/// - Identity must never change
///
/// Lifecycle:
/// - Created → Modified → Archived (example)
/// </remarks>
public class Order
{
    public OrderId Id { get; }
    public decimal Amount { get; private set; }

    public Order(OrderId id, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Id = id;
        Amount = amount;
    }

    public void UpdateAmount(decimal newAmount)
    {
        if (newAmount <= 0)
            throw new ArgumentException("Amount must be positive.");

        Amount = newAmount;
    }
}
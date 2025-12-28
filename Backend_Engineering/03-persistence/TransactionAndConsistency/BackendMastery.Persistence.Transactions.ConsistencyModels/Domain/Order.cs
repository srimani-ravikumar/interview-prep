namespace BackendMastery.Persistence.Transactions.ConsistencyModels.Domain;

/// <summary>
/// Represents an order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Order creation requires strong consistency
/// - Status updates can be eventual
///
/// USE CASE:
/// - Order placed → immediately confirmed
/// - Status update may lag slightly
/// </remarks>
public class Order
{
    public Guid Id { get; } = Guid.NewGuid();
    public OrderStatus Status { get; private set; }

    public Order()
    {
        Status = OrderStatus.Placed;
    }

    public void MarkShipped()
    {
        Status = OrderStatus.Shipped;
    }
}
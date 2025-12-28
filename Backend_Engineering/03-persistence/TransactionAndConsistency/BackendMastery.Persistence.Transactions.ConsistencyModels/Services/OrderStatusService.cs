using BackendMastery.Persistence.Transactions.ConsistencyModels.Domain;
using BackendMastery.Persistence.Transactions.ConsistencyModels.Stores;

namespace BackendMastery.Persistence.Transactions.ConsistencyModels.Services;

/// <summary>
/// Chooses consistency model based on use case.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Not all reads need strong consistency
/// - Consistency choice is a business decision
///
/// KEY RULE:
/// ❗ Decide consistency per operation, not per system
/// </remarks>
public class OrderStatusService
{
    private readonly StronglyConsistentStore _strongStore = new();
    private readonly EventuallyConsistentStore _eventualStore = new();

    public void PlaceOrder(Order order)
    {
        // Strong consistency
        _strongStore.Write(order.Id, order.Status);

        // Eventual consistency
        _eventualStore.WriteAsync(order.Id, order.Status);
    }

    public void ShipOrder(Order order)
    {
        order.MarkShipped();

        _strongStore.Write(order.Id, order.Status);
        _eventualStore.WriteAsync(order.Id, order.Status);
    }

    public OrderStatus GetStrongStatus(Guid orderId)
        => _strongStore.Read(orderId);

    public OrderStatus? GetEventualStatus(Guid orderId)
        => _eventualStore.Read(orderId);
}
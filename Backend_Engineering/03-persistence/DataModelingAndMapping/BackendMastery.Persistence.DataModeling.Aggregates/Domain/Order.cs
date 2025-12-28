using System.Collections.ObjectModel;

namespace BackendMastery.Persistence.DataModeling.Aggregates.Domain;

/// <summary>
/// Aggregate Root: Order
/// </summary>
/// <remarks>
/// INTUITION:
/// - Aggregate root controls access to internal entities
/// - All consistency rules are enforced here
///
/// RULE:
/// - External code must NEVER modify OrderItems directly
/// </remarks>
public class Order
{
    public OrderId Id { get; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items =>
        new ReadOnlyCollection<OrderItem>(_items);

    public decimal TotalAmount =>
        _items.Sum(i => i.Price * i.Quantity);

    public Order(OrderId id)
    {
        Id = id;
    }

    public void AddItem(string sku, decimal price, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive.");

        if (price <= 0)
            throw new ArgumentException("Price must be positive.");

        _items.Add(new OrderItem(sku, price, quantity));
    }
}
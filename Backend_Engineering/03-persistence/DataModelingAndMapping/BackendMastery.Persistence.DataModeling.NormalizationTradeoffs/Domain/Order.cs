namespace BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Domain;

/// <summary>
/// Domain entity representing an Order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Domain model stays normalized
/// - Business rules live here
/// </remarks>
public class Order
{
    public OrderId Id { get; }
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public decimal TotalAmount => _items.Sum(i => i.Price * i.Quantity);

    public Order(OrderId id)
    {
        Id = id;
    }

    public void AddItem(string sku, decimal price, int quantity)
    {
        _items.Add(new OrderItem(sku, price, quantity));
    }
}
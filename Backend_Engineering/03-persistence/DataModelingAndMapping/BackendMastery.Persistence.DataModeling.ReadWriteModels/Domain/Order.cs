namespace BackendMastery.Persistence.DataModeling.ReadWriteModels.Domain;

/// <summary>
/// Write model (aggregate).
/// </summary>
/// <remarks>
/// INTUITION:
/// - Protects business invariants
/// - Used for commands (Create, Update)
/// </remarks>
public class Order
{
    public OrderId Id { get; }
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

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

        _items.Add(new OrderItem(sku, price, quantity));
    }
}
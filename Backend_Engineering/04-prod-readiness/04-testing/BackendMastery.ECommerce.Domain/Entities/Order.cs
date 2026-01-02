using BackendMastery.ECommerce.Domain.ValueObjects;

namespace BackendMastery.ECommerce.Domain.Entities;

/// <summary>
/// Aggregate root for order.
/// All modifications go through this class.
/// </summary>
public class Order
{
    private readonly List<OrderItem> _items = new();

    public Guid Id { get; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Order Id cannot be empty");

        Id = id;
    }

    public void AddItem(Product product, int quantity)
    {
        var item = new OrderItem(product, quantity);
        _items.Add(item);
    }

    public Money TotalAmount()
    {
        return _items
            .Select(i => i.TotalPrice())
            .Aggregate(Money.Zero(), (sum, current) => sum.Add(current));
    }
}
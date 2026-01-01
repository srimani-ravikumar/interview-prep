using BackendMastery.Persistence.EFCore.CodeFirst.Domain.ValueObjects;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;

/// <summary>
/// Aggregate root.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Order is the consistency boundary
/// - Items cannot exist without Order
///
/// KEY RULE:
/// ❗ Aggregate root controls invariants
/// </remarks>
public class Order
{
    public Guid Id { get; private set; }
    public Money Total { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items;

    private Order() { } // EF Core

    public Order(Money total)
    {
        Id = Guid.NewGuid();
        Total = total;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(string productName, int quantity)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("Invalid quantity");

        _items.Add(new OrderItem(productName, quantity));
    }
}
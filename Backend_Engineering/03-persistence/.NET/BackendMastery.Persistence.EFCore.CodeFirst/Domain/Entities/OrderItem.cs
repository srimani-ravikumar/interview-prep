namespace BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;

/// <summary>
/// Dependent entity.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Exists only inside Order
///
/// KEY RULE:
/// ❗ No aggregate crossing
/// </remarks>
public class OrderItem
{
    public Guid Id { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }

    private OrderItem() { }

    internal OrderItem(string productName, int quantity)
    {
        Id = Guid.NewGuid();
        ProductName = productName;
        Quantity = quantity;
    }
}
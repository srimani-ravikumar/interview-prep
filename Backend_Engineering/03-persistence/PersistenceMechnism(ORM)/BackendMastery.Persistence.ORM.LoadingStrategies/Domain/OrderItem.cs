namespace BackendMastery.Persistence.ORM.LoadingStrategies.Domain;

/// <summary>
/// Represents an item inside an order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Pure domain object
/// - No knowledge of loading strategy
///
/// KEY RULE:
/// ❗ Domain must not trigger data access
/// </remarks>
public class OrderItem
{
    public string Name { get; }
    public decimal Price { get; }

    public OrderItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
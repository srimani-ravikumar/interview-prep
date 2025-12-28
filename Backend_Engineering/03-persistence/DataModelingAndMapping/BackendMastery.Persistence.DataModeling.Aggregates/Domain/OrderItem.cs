namespace BackendMastery.Persistence.DataModeling.Aggregates.Domain;

/// <summary>
/// Internal entity inside the Order aggregate.
/// </summary>
/// <remarks>
/// INTUITION:
/// - OrderItem has identity inside the aggregate
/// - It has NO meaning outside Order
///
/// RULE:
/// - Must never be modified directly by external code
/// </remarks>
public class OrderItem
{
    public string Sku { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    internal OrderItem(string sku, decimal price, int quantity)
    {
        Sku = sku;
        Price = price;
        Quantity = quantity;
    }
}
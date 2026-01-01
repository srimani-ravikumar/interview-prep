namespace BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Domain;

/// <summary>
/// Represents inventory for a product.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Inventory is CRITICAL data
/// - Wrong inventory = overselling or financial loss
///
/// USE CASE:
/// - E-commerce stock
/// - Warehouse item count
///
/// KEY RULE:
/// ❗ Critical state must NEVER be guessed or defaulted
/// </remarks>
public class InventoryItem
{
    public string ProductId { get; }
    public int Quantity { get; private set; }

    public InventoryItem(string productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public void Reduce(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Reduction amount must be positive");

        if (Quantity < amount)
            throw new InvalidOperationException("Insufficient inventory");

        Quantity -= amount;
    }
}
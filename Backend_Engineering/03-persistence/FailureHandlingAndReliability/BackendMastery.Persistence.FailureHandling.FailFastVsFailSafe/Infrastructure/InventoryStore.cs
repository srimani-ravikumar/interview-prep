using BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Domain;

namespace BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Infrastructure;

/// <summary>
/// Simulates a persistent inventory store.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Persistence can fail (timeouts, disk issues)
/// - Failure here is NOT always exceptional
///
/// USE CASE:
/// - Database temporarily unavailable
///
/// KEY RULE:
/// ❗ Write failures on critical data must FAIL FAST
/// </remarks>
public class InventoryStore
{
    private readonly Dictionary<string, InventoryItem> _items = new();

    public void Add(InventoryItem item)
    {
        _items[item.ProductId] = item;
    }

    public InventoryItem Get(string productId)
    {
        // Simulate a persistence failure
        if (Random.Shared.Next(0, 4) == 0)
            throw new Exception("Inventory DB unavailable");

        return _items[productId];
    }

    public void Save(InventoryItem item)
    {
        // Simulate write failure
        if (Random.Shared.Next(0, 4) == 0)
            throw new Exception("Failed to persist inventory update");

        _items[item.ProductId] = item;
    }
}
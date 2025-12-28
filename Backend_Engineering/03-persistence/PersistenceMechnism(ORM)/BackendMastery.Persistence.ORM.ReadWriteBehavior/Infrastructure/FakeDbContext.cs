using BackendMastery.Persistence.ORM.ReadWriteBehavior.Domain;

namespace BackendMastery.Persistence.ORM.ReadWriteBehavior.Infrastructure;

/// <summary>
/// Simulates read vs write query behavior.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Tracking enables updates
/// - No-tracking optimizes reads
///
/// USE CASE:
/// - Reporting queries
/// - Command handling
///
/// KEY RULE:
/// ❗ Tracking should be an explicit decision
/// </remarks>
public class FakeDbContext
{
    private readonly Dictionary<int, Order> _trackedEntities = new();

    // WRITE PATH — tracked
    public Order GetOrderForUpdate(int id)
    {
        Console.WriteLine("Loading Order for UPDATE (tracked)");

        var order = new Order(id, "Pending", 2500);

        _trackedEntities[id] = order;
        return order;
    }

    // READ PATH — no tracking
    public Order GetOrderForRead(int id)
    {
        Console.WriteLine("Loading Order for READ (no tracking)");

        return new Order(id, "Pending", 2500);
    }

    public void SaveChanges()
    {
        Console.WriteLine("\n--- SaveChanges ---");

        foreach (var order in _trackedEntities.Values)
        {
            Console.WriteLine(
                $"UPDATE Orders SET Status='{order.Status}' WHERE Id={order.Id}");
        }
    }
}
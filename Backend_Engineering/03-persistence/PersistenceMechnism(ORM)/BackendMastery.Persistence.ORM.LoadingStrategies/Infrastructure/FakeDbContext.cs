using BackendMastery.Persistence.ORM.LoadingStrategies.Domain;

namespace BackendMastery.Persistence.ORM.LoadingStrategies.Infrastructure;

/// <summary>
/// Simulates lazy vs eager loading.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Lazy loading defers IO
/// - Eager loading makes IO explicit
///
/// KEY RULE:
/// ❗ IO must be explicit and predictable
/// </remarks>
public class FakeDbContext
{
    // Lazy loading
    public Order GetOrderLazy(int id)
    {
        Console.WriteLine("Loading Order (without items)");

        return new Order(id, LoadOrderItems);
    }

    // Eager loading
    public Order GetOrderEager(int id)
    {
        Console.WriteLine("Loading Order WITH items (eager)");

        var items = LoadOrderItems();
        return new Order(id, () => items);
    }

    private List<OrderItem> LoadOrderItems()
    {
        Console.WriteLine("Fetching OrderItems from database");
        return new List<OrderItem>
        {
            new OrderItem("Keyboard", 1500),
            new OrderItem("Mouse", 500)
        };
    }
}
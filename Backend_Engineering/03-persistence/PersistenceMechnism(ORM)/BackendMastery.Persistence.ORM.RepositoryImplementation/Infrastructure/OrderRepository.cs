using BackendMastery.Persistence.ORM.RepositoryImplementation.Domain;

namespace BackendMastery.Persistence.ORM.RepositoryImplementation.Infrastructure;

/// <summary>
/// Simulates ORM-backed repository.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This is where persistence mechanics live
/// - Tracking, queries, mapping stay here
///
/// USE CASE:
/// - Load tracked entities
///
/// KEY RULE:
/// ❗ Infrastructure depends on domain, never the reverse
/// </remarks>
public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<int, Order> _store = new();

    public OrderRepository()
    {
        _store[1] = new Order(1, 3000);
    }

    public Order GetByIdForUpdate(int id)
    {
        Console.WriteLine("Loading Order for update (tracked)");
        return _store[id];
    }

    public void Save(Order order)
    {
        Console.WriteLine(
            $"Persisting Order {order.Id} with Status='{order.Status}'");
    }
}
using BackendMastery.Architecture.Repository.Service.Models;

namespace BackendMastery.Architecture.Repository.Service.Repositories;

/// <summary>
/// In-memory order repository.
/// </summary>
/// <remarks>
/// Intuition:
/// - Concrete persistence implementation
/// - Easily replaceable with DB-based repo
///
/// Reason to change:
/// - Storage mechanism changes
/// </remarks>
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _store = new();

    public void Save(Order order)
    {
        _store[order.Id] = order;
    }

    public Order? GetById(Guid id)
    {
        return _store.TryGetValue(id, out var order)
            ? order
            : null;
    }
}
using BackendMastery.Architecture.SoC.Repository.Service.Models;

namespace BackendMastery.Architecture.SoC.Repository.Service.Repositories;

/// <summary>
/// In-memory repository implementation.
/// </summary>
/// <remarks>
/// Intuition:
/// - Concrete persistence
/// - Easily replaceable with DB-backed repo
///
/// Reason to change:
/// - Storage technology changes
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
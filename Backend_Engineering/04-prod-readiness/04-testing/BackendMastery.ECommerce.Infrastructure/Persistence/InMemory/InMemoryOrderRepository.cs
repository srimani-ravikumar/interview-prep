using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Domain.Entities;

namespace BackendMastery.ECommerce.Infrastructure.Persistence.InMemory;

/// <summary>
/// In-memory implementation of order repository.
/// </summary>
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _store = new();

    public Task AddAsync(Order order)
    {
        _store[order.Id] = order;
        return Task.CompletedTask;
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        _store.TryGetValue(id, out var order);
        return Task.FromResult(order);
    }
}
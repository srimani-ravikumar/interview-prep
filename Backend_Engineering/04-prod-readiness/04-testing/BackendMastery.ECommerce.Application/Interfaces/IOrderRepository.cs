using BackendMastery.ECommerce.Domain.Entities;

namespace BackendMastery.ECommerce.Application.Interfaces;

/// <summary>
/// Abstraction over order persistence.
/// </summary>
public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
}
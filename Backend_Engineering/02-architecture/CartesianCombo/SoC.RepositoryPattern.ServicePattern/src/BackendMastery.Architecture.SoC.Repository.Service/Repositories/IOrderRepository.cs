using BackendMastery.Architecture.SoC.Repository.Service.Models;

namespace BackendMastery.Architecture.SoC.Repository.Service.Repositories;

/// <summary>
/// Repository abstraction for orders.
/// </summary>
/// <remarks>
/// Intuition:
/// - Isolates persistence
/// - Hides storage mechanics
///
/// Repository never contains business rules.
/// </remarks>
public interface IOrderRepository
{
    void Save(Order order);
    Order? GetById(Guid id);
}
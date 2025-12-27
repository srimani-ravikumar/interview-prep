using BackendMastery.Architecture.Repository.Service.Models;

namespace BackendMastery.Architecture.Repository.Service.Repositories;

/// <summary>
/// Repository abstraction for orders.
/// </summary>
/// <remarks>
/// Intuition:
/// - Defines HOW orders are persisted/retrieved
/// - Hides storage details
///
/// Repository does NOT:
/// - Apply business rules
/// - Coordinate workflows
/// </remarks>
public interface IOrderRepository
{
    void Save(Order order);
    Order? GetById(Guid id);
}
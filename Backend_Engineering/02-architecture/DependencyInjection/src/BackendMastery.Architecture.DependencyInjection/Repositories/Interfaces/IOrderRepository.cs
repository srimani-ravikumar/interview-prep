using BackendMastery.Architecture.DependencyInjection.Models;

namespace BackendMastery.Architecture.DependencyInjection.Repositories.Interfaces;

/// <summary>
/// Repository abstraction.
/// </summary>
/// <remarks>
/// Intuition:
/// - Defines WHAT data access is needed, not HOW.
/// - Allows swapping implementations without touching business logic.
///
/// Use case:
/// - InMemory today
/// - EF Core tomorrow
/// - Mock in tests
/// </remarks>
public interface IOrderRepository
{
    void Add(Order order);
    IEnumerable<Order> GetAll();
}
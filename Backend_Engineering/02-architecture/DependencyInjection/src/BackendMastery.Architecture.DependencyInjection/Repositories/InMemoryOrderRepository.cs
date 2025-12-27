using BackendMastery.Architecture.DependencyInjection.Models;
using BackendMastery.Architecture.DependencyInjection.Repositories.Interfaces;

namespace BackendMastery.Architecture.DependencyInjection.Repositories;

/// <summary>
/// Concrete repository implementation.
/// </summary>
/// <remarks>
/// Intuition:
/// - This class KNOWS how data is stored.
/// - Higher layers should not care.
///
/// Use case:
/// - Fast prototyping
/// - Unit tests
/// </remarks>
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public void Add(Order order) => _orders.Add(order);

    public IEnumerable<Order> GetAll() => _orders;
}
using BackendMastery.Architecture.DependencyInjection.Infrastructure;
using BackendMastery.Architecture.DependencyInjection.Models;
using BackendMastery.Architecture.DependencyInjection.Repositories.Interfaces;
using BackendMastery.Architecture.DependencyInjection.Services.Interfaces;

namespace BackendMastery.Architecture.DependencyInjection.Services;

/// <summary>
/// Business service using constructor injection.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Dependencies are REQUIRED, not optional.
/// - Constructor injection enforces correctness at creation time.
/// </para>
/// <para>
/// Use case:
/// - Makes invalid states unrepresentable.
/// - Enables easy mocking in tests.
/// </para>
/// </remarks>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly ISystemClock _clock;

    // Constructor Injection (Preferred)
    public OrderService(
        IOrderRepository repository,
        ISystemClock clock)
    {
        _repository = repository;
        _clock = clock;
    }

    public void CreateOrder(string product)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Product = product,
            CreatedAt = _clock.UtcNow
        };

        _repository.Add(order);
    }

    public IEnumerable<Order> GetOrders() => _repository.GetAll();
}
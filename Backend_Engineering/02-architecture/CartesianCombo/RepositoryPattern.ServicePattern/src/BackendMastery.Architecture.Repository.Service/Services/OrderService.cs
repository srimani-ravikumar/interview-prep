using BackendMastery.Architecture.Repository.Service.Models;
using BackendMastery.Architecture.Repository.Service.Repositories;

namespace BackendMastery.Architecture.Repository.Service.Services;

/// <summary>
/// Implements order placement behavior.
/// </summary>
/// <remarks>
/// Intuition:
/// - Applies business rules
/// - Coordinates persistence
///
/// This is the Service Pattern:
/// - Business logic lives here
/// - Repository is used, not exposed
/// </remarks>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Order PlaceOrder(decimal amount)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Amount = amount,
            IsPriority = amount > 1000 // simple business rule
        };

        _repository.Save(order);

        return order;
    }
}
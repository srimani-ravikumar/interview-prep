using BackendMastery.Architecture.SoC.Repository.Service.Models;
using BackendMastery.Architecture.SoC.Repository.Service.Repositories;
using BackendMastery.Architecture.SoC.Repository.Service.Validation;

namespace BackendMastery.Architecture.SoC.Repository.Service.Services;

/// <summary>
/// Implements order processing behavior.
/// </summary>
/// <remarks>
/// Intuition:
/// - Applies business rules
/// - Coordinates validation and persistence
///
/// This is the Service Pattern in action.
/// </remarks>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly OrderValidator _validator;

    public OrderService(
        IOrderRepository repository,
        OrderValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Order PlaceOrder(decimal amount)
    {
        if (!_validator.IsValid(amount))
            throw new ArgumentException("Invalid order amount");

        var order = new Order
        {
            Id = Guid.NewGuid(),
            Amount = amount,
            IsPriority = amount > 1000
        };

        _repository.Save(order);

        return order;
    }
}
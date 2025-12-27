using BackendMastery.StandardAPI.Application.Interfaces.Repositories;
using BackendMastery.StandardAPI.Application.Interfaces.Services;
using BackendMastery.StandardAPI.Domain.Models;
using BackendMastery.StandardAPI.Application.Validators;

namespace BackendMastery.StandardAPI.Application.Services;

/// <summary>
/// Implements Order-related business workflows.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Orchestrates domain creation + persistence
/// - Owns application-level workflows
/// </para>
/// <para>
/// This class:
/// - Uses repositories
/// - Creates domain entities
/// - Does NOT know about HTTP or EF Core
/// </para>
/// </remarks>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly CreateOrderValidator _validator;

    public OrderService(IOrderRepository orderRepository, CreateOrderValidator validator)
    {
        _orderRepository = orderRepository;
        _validator = validator;
    }

    /// <summary>
    /// Places a new order.
    /// </summary>
    public async Task<Order> PlaceOrderAsync(decimal amount)
    {
        _validator.Validate(amount);

        // Domain enforces invariants (fail-fast)
        var order = new Order(amount);

        // Application decides persistence
        await _orderRepository.AddAsync(order);

        return order;
    }

    /// <summary>
    /// Retrieves an order by ID.
    /// </summary>
    public Task<Order?> GetOrderByIdAsync(Guid id)
    {
        return _orderRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    public Task<IReadOnlyList<Order>> GetAllOrdersAsync()
    {
        return _orderRepository.GetAllAsync();
    }
}
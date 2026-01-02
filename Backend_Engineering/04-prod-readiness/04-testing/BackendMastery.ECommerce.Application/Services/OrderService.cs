using BackendMastery.ECommerce.Application.Exceptions;
using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Domain.Entities;

namespace BackendMastery.ECommerce.Application.Services;

/// <summary>
/// Coordinates order creation workflow.
/// </summary>
public class OrderService
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Guid> CreateOrderAsync(
        Guid productId,
        int quantity)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        if (product is null)
            throw new NotFoundException("Product not found");

        var order = new Order(Guid.NewGuid());
        order.AddItem(product, quantity);

        await _orderRepository.AddAsync(order);
        return order.Id;
    }
}
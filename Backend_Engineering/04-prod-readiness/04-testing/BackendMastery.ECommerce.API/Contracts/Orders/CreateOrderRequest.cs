namespace BackendMastery.ECommerce.API.Contracts.Orders;

/// <summary>
/// Request contract for creating an order.
/// </summary>
public record CreateOrderRequest(
    Guid ProductId,
    int Quantity
);
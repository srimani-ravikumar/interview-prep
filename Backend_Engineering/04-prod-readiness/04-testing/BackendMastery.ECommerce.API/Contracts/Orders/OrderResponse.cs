namespace BackendMastery.ECommerce.API.Contracts.Orders;

/// <summary>
/// Minimal order response.
/// </summary>
public record OrderResponse(
    Guid OrderId,
    decimal TotalAmount
);
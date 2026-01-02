using BackendMastery.ECommerce.API.Contracts.Orders;
using BackendMastery.ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ECommerce.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateOrderRequest request)
    {
        var orderId = await _orderService.CreateOrderAsync(
            request.ProductId,
            request.Quantity);

        // NOTE: total is domain-calculated, not API-calculated
        var response = new OrderResponse(
            OrderId: orderId,
            TotalAmount: 0 // will be fetched later if needed
        );

        return CreatedAtAction(
            nameof(Create),
            new { id = orderId },
            response);
    }
}
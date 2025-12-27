using BackendMastery.Architecture.StandardAPI.Api.DTOs;
using BackendMastery.Architecture.StandardAPI.Application.Interfaces.Services;
using BackendMastery.Architecture.StandardAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.Architecture.StandardAPI.Api.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    // Constructor injection
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // ---------------------------------------
    // POST /api/v1/orders
    // ---------------------------------------

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <remarks>
    /// Intuition:
    /// - POST is non-idempotent
    /// - Creates a new resource
    ///
    /// Controller responsibility:
    /// - Translate HTTP → use case
    /// - Map domain → DTO
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        Order order = await _orderService.PlaceOrderAsync(request.Amount);

        var response = MapToResponse(order);

        return CreatedAtAction(
            nameof(GetById),
            new { id = response.Id },
            response);
    }

    // ---------------------------------------
    // GET /api/v1/orders/{id}
    // ---------------------------------------

    /// <summary>
    /// Retrieves an order by ID.
    /// </summary>
    /// <remarks>
    /// Intuition:
    /// - GET is safe & idempotent
    /// </remarks>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Order? order = await _orderService.GetOrderByIdAsync(id);

        if (order is null)
            return NotFound();

        return Ok(MapToResponse(order));
    }

    // ---------------------------------------
    // GET /api/v1/orders
    // ---------------------------------------

    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IReadOnlyList<Order> orders =
            await _orderService.GetAllOrdersAsync();

        var response = orders
            .Select(MapToResponse)
            .ToList();

        return Ok(response);
    }

    // ---------------------------------------
    // Mapping (private helper)
    // ---------------------------------------

    private static OrderResponse MapToResponse(Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            Amount = order.Amount,
            IsPriority = order.IsPriority
        };
    }
}
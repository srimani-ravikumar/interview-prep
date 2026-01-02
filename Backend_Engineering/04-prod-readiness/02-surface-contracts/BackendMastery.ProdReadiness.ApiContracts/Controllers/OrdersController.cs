using BackendMastery.ProdReadiness.ApiContracts.Contracts.Requests;
using BackendMastery.ProdReadiness.ApiContracts.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.ApiContracts.Controllers;

/// <summary>
/// INTUITION:
/// Controllers define the API SURFACE, not business logic.
/// 
/// USE CASE:
/// Acts as the boundary between consumers and internal systems.
/// 
/// FAILURE MODE:
/// Mixing logic here causes contract changes during refactors.
/// </summary>
[ApiController]
[Route("api/v1/orders")]
public sealed class OrdersController : ControllerBase
{
    /// <summary>
    /// Creates an order.
    /// 
    /// CONTRACT GUARANTEES:
    /// - 201 Created on success
    /// - Stable response shape
    /// 
    /// NOTE:
    /// No validation or persistence — this project isolates contracts only.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] CreateOrderRequest request)
    {
        // Simulated behavior — logic is irrelevant for contract demonstration
        var response = new OrderResponse
        {
            OrderId = Guid.NewGuid(),
            Status = "Created"
        };

        return CreatedAtAction(nameof(GetById), new { id = response.OrderId }, response);
    }

    /// <summary>
    /// Retrieves an order by identifier.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var response = new OrderResponse
        {
            OrderId = id,
            Status = "Created"
        };

        return Ok(response);
    }
}
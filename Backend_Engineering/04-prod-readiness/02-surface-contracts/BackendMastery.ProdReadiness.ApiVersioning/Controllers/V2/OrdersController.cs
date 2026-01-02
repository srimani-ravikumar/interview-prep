using BackendMastery.ProdReadiness.ApiVersioning.Contracts.V2;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.ApiVersioning.Controllers.V2;

/// <summary>
/// INTUITION:
/// V2 represents a consciously broken contract.
///
/// USE CASE:
/// Allows evolution without forcing upgrades.
/// </summary>
[ApiController]
[Route("api/v2/orders")]
public sealed class OrdersController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        return Ok(new OrderResponse
        {
            OrderId = id,
            State = "COMPLETED",
            Amount = 500,
            Currency = "INR"
        });
    }
}
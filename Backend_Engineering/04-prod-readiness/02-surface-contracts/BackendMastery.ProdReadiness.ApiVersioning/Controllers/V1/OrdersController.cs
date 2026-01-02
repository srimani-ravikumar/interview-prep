using BackendMastery.ProdReadiness.ApiVersioning.Contracts.V1;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.ApiVersioning.Controllers.V1;

/// <summary>
/// INTUITION:
/// V1 must remain stable forever (or until sunset).
///
/// FAILURE MODE:
/// Modifying this controller breaks old clients.
/// </summary>
[ApiController]
[Route("api/v1/orders")]
public sealed class OrdersController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        return Ok(new OrderResponse
        {
            OrderId = id,
            Status = "PAID",
            TotalAmount = 500
        });
    }
}
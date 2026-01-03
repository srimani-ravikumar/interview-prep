using BackendMastery.ProdReadiness.Observability.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Observability.Controllers;

/// <summary>
/// Orders API.
///
/// WHY THIS EXISTS:
/// Demonstrates correlation-aware
/// request handling.
///
/// WHAT BREAKS IF MISUSED:
/// Returning generic 500s without context.
/// </summary>
[ApiController]
[Route("api/orders")]
public sealed class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CancellationToken cancellationToken)
    {
        var response = await _service
            .CreateAsync(cancellationToken);

        return Ok(response);
    }
}
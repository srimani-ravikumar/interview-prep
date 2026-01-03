using BackendMastery.ProdReadiness.Idempotency.Contracts;
using BackendMastery.ProdReadiness.Idempotency.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Idempotency.Controllers;

/// <summary>
/// Handles order creation requests.
///
/// WHY THIS EXISTS:
/// Demonstrates safe write behavior under retries.
///
/// WHAT BREAKS IF MISUSED:
/// Write endpoints without idempotency
/// cause irreversible business damage.
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
        CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _service
            .CreateOrderAsync(request, cancellationToken);

        return Ok(result);
    }
}
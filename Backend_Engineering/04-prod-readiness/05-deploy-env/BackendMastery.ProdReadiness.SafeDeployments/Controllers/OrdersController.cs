using BackendMastery.ProdReadiness.SafeDeployments.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.SafeDeployments.Controllers;

/// <summary>
/// WHY:
/// Demonstrates safe evolution of API responses.
///
/// WHAT PROBLEM IT SOLVES:
/// Avoids breaking existing clients during rollout.
///
/// WHAT BREAKS IF MISUSED:
/// Removing fields causes immediate client failures.
/// </summary>
[ApiController]
[Route("orders")]
public sealed class OrdersController : ControllerBase
{
    private readonly OrderService _service;

    public OrdersController(OrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetOrder());
    }
}
using BackendMastery.ProdReadiness.GracefulDegradation.Infrastructure;
using BackendMastery.ProdReadiness.GracefulDegradation.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.GracefulDegradation.Controllers;

/// <summary>
/// Checkout API.
///
/// WHY THIS EXISTS:
/// Demonstrates prioritization under load.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers should not decide degradation.
/// </summary>
[ApiController]
[Route("api/checkout")]
public sealed class CheckoutController : ControllerBase
{
    private readonly ICheckoutService _service;
    private readonly LoadMonitor _monitor;

    public CheckoutController(
        ICheckoutService service,
        LoadMonitor monitor)
    {
        _service = service;
        _monitor = monitor;
    }

    [HttpPost]
    public async Task<IActionResult> Checkout(
        CancellationToken cancellationToken)
    {
        _monitor.Increment();

        try
        {
            var response = await _service
                .CheckoutAsync(cancellationToken);

            return Ok(response);
        }
        finally
        {
            _monitor.Decrement();
        }
    }
}
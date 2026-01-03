using BackendMastery.ProdReadiness.CircuitBreakers.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.CircuitBreakers.Controllers;

/// <summary>
/// Exposes payment processing endpoint.
///
/// WHY THIS EXISTS:
/// Converts domain outcomes into HTTP semantics.
///
/// WHAT BREAKS IF MISUSED:
/// Leaking domain primitives into APIs.
/// </summary>
[ApiController]
[Route("api/payments")]
public sealed class PaymentsController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentsController(IPaymentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Process(
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _service
                .ProcessPaymentAsync(cancellationToken);

            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            // Breaker-open scenario
            return StatusCode(503, new
            {
                Error = ex.Message
            });
        }
    }
}
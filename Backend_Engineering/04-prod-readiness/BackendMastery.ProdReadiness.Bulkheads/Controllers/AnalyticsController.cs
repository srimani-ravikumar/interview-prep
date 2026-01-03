using BackendMastery.ProdReadiness.Bulkheads.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Bulkheads.Controllers;

/// <summary>
/// Analytics API.
///
/// WHY THIS EXISTS:
/// Remains responsive even under report overload.
/// </summary>
[ApiController]
[Route("api/analytics")]
public sealed class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _service;

    public AnalyticsController(IAnalyticsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken)
    {
        return Ok(await _service.ProcessAsync(cancellationToken));
    }
}
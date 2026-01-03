using BackendMastery.ProdReadiness.Bulkheads.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Bulkheads.Controllers;

/// <summary>
/// Report API.
///
/// WHY THIS EXISTS:
/// Demonstrates how overload is contained
/// within reporting feature.
/// </summary>
[ApiController]
[Route("api/reports")]
public sealed class ReportsController : ControllerBase
{
    private readonly IReportsService _service;

    public ReportsController(IReportsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _service.GenerateAsync(cancellationToken));
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(429, ex.Message);
        }
    }
}
using BackendMastery.ProdReadiness.Retries.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Retries.Controllers;

/// <summary>
/// Exposes report retrieval endpoint.
///
/// WHY THIS EXISTS:
/// Demonstrates how retries reduce transient errors
/// without changing API semantics.
///
/// WHAT PROBLEM THIS SOLVES:
/// Improves reliability without retrying at client side.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers should never implement retry loops.
/// </summary>
[ApiController]
[Route("api/reports")]
public sealed class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken)
    {
        var report = await _service
            .GetReportAsync(cancellationToken);

        return Ok(report);
    }
}
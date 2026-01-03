using BackendMastery.ProdReadiness.Timeouts.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendMastery.ProdReadiness.Timeouts.Controllers;

/// <summary>
/// Entry point for client requests.
///
/// WHY THIS EXISTS:
/// Demonstrates how timeout failures surface
/// as controlled API errors.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents client requests from hanging indefinitely.
///
/// WHEN TO USE:
/// Every public API endpoint.
///
/// WHAT BREAKS IF MISUSED:
/// Silent hangs lead to retries and traffic amplification.
/// </summary>
[ApiController]
[Route("api/weather")]
public sealed class WeatherController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherController(IWeatherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        CancellationToken cancellationToken)
    {
        try
        {
            var weather = await _service
                .GetWeatherAsync(cancellationToken);

            return Ok(weather);
        }
        catch (TimeoutException ex)
        {
            // Explicit timeout failure is better
            // than implicit system collapse.
            return StatusCode(504, ex.Message);
        }
    }
}
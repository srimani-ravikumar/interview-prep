using BackendMastery.ApiProduction.EnvironmentConfiguration.Contracts;
using BackendMastery.ApiProduction.EnvironmentConfiguration.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackendMastery.ApiProduction.EnvironmentConfiguration.Controllers;

/// <summary>
/// WHY:
/// Demonstrates environment-specific behavior without code changes.
///
/// WHAT PROBLEM IT SOLVES:
/// Allows safe introspection only where permitted.
///
/// WHEN TO USE:
/// Diagnostics, health probes, internal metadata.
///
/// WHAT BREAKS IF MISUSED:
/// Production systems leak internal details.
/// </summary>
[ApiController]
[Route("diagnostics")]
public sealed class DiagnosticsController : ControllerBase
{
    private readonly EnvironmentOptions _options;

    public DiagnosticsController(IOptions<EnvironmentOptions> options)
    {
        _options = options.Value;
    }

    [HttpGet("environment")]
    public ActionResult<EnvironmentInfoResponse> Get()
    {
        return new EnvironmentInfoResponse
        {
            Environment = _options.EnvironmentName,
            VerboseLoggingEnabled = _options.EnableVerboseLogging,
            TimeoutSeconds = _options.ExternalServiceTimeoutSeconds
        };
    }
}
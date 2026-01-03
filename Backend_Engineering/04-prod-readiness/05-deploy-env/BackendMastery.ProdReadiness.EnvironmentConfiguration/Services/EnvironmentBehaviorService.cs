using BackendMastery.ApiProduction.EnvironmentConfiguration.Configuration;
using Microsoft.Extensions.Options;

namespace BackendMastery.ApiProduction.EnvironmentConfiguration.Services;

/// <summary>
/// WHY:
/// Centralizes environment-driven behavior.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents controllers from knowing environment rules.
///
/// WHEN TO USE:
/// Any decision that depends on environment constraints.
///
/// WHAT BREAKS IF MISUSED:
/// Controllers become environment-aware and untestable.
/// </summary>
public sealed class EnvironmentBehaviorService
{
    private readonly EnvironmentOptions _options;

    public EnvironmentBehaviorService(IOptions<EnvironmentOptions> options)
    {
        _options = options.Value;
    }

    public bool IsDiagnosticsAllowed()
    {
        return _options.AllowDiagnosticEndpoints;
    }
}
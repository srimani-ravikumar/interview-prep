namespace BackendMastery.ApiProduction.EnvironmentConfiguration.Configuration;

/// <summary>
/// WHY:
/// Centralizes environment-dependent behavior without polluting code with conditionals.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents hard-coded environment logic and behavior drift.
///
/// WHEN TO USE:
/// Any behavior that must differ between Dev / Staging / Prod.
///
/// WHAT BREAKS IF MISUSED:
/// Missing defaults cause startup failures in production.
/// </summary>
public sealed class EnvironmentOptions
{
    public string EnvironmentName { get; init; } = "Unknown";

    public bool EnableVerboseLogging { get; init; }

    public int ExternalServiceTimeoutSeconds { get; init; }

    public bool AllowDiagnosticEndpoints { get; init; }
}
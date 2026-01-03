namespace BackendMastery.ApiProduction.EnvironmentConfiguration.Contracts;

/// <summary>
/// WHY:
/// Represents a safe, read-only view of environment-dependent behavior.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents leaking raw configuration or internal objects directly to callers.
///
/// WHEN TO USE:
/// Any time you want to expose environment or diagnostics data externally.
///
/// WHAT BREAKS IF MISUSED:
/// Exposing internal configuration objects can leak sensitive or unstable fields.
/// </summary>
public sealed class EnvironmentInfoResponse
{
    public string Environment { get; init; } = string.Empty;

    public bool VerboseLoggingEnabled { get; init; }

    public int TimeoutSeconds { get; init; }
}
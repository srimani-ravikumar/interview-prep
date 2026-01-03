namespace BackendMastery.ProdReadiness.Timeouts.Configuration;

/// <summary>
/// Represents explicit timeout budgets for external dependencies.
/// 
/// WHY:
/// Timeouts must be configurable because safe values change
/// across environments (local, staging, prod).
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents hardcoded timeout values from silently
/// causing outages during traffic or latency spikes.
///
/// WHEN TO USE:
/// Any time you depend on a remote system.
///
/// WHAT BREAKS IF MISUSED:
/// Too large → slow resource exhaustion.
/// Too small → false failures.
/// </summary>
public sealed class TimeoutOptions
{
    public int ExternalWeatherApiMilliseconds { get; init; }
}
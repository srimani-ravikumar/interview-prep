namespace BackendMastery.ProdReadiness.Retries.Configuration;

/// <summary>
/// Defines retry behavior for transient failures.
///
/// WHY THIS EXISTS:
/// Retry limits and delays must be explicit and configurable.
/// Hardcoded retries cause outages under load.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents infinite or aggressive retry loops.
///
/// WHEN TO USE:
/// Any interaction with unreliable dependencies.
///
/// WHAT BREAKS IF MISUSED:
/// - Too many retries → outage amplification
/// - No delay → retry storms
/// </summary>
public sealed class RetryOptions
{
    public int MaxAttempts { get; init; }
    public int BaseDelayMilliseconds { get; init; }
}
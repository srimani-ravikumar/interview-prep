namespace BackendMastery.ProdReadiness.CircuitBreakers.Configuration;

/// <summary>
/// Defines circuit breaker thresholds.
///
/// WHY THIS EXISTS:
/// Breaker tuning is environment- and dependency-specific.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents hardcoded thresholds from causing
/// false trips or slow recovery.
///
/// WHAT BREAKS IF MISUSED:
/// - Too sensitive → constant open state
/// - Too lenient → cascading failures
/// </summary>
public sealed class CircuitBreakerOptions
{
    public int FailureThreshold { get; init; }
    public int OpenStateDurationSeconds { get; init; }
}
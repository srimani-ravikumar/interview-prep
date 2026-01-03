namespace BackendMastery.ProdReadiness.CircuitBreakers.Infrastructure;

/// <summary>
/// Implements a basic circuit breaker state machine.
///
/// WHY THIS EXISTS:
/// Systems must stop calling dependencies
/// that are clearly unhealthy.
///
/// STATES:
/// - Closed: normal operation
/// - Open: calls are blocked
/// - Half-Open: probing for recovery
///
/// WHAT BREAKS IF MISUSED:
/// No breaker → cascading failures.
/// Global breaker → over-blocking.
/// </summary>
public sealed class CircuitBreaker
{
    private int _failureCount;
    private DateTime? _openedAt;

    private readonly int _failureThreshold;
    private readonly TimeSpan _openDuration;

    public CircuitBreaker(int failureThreshold, TimeSpan openDuration)
    {
        _failureThreshold = failureThreshold;
        _openDuration = openDuration;
    }

    public bool IsOpen =>
        _openedAt.HasValue &&
        DateTime.UtcNow - _openedAt < _openDuration;

    public bool AllowRequest()
    {
        // Open state: reject calls immediately
        if (IsOpen)
            return false;

        // Half-open: allow a probe call
        return true;
    }

    public void RecordSuccess()
    {
        // Successful call means dependency recovered
        _failureCount = 0;
        _openedAt = null;
    }

    public void RecordFailure()
    {
        _failureCount++;

        if (_failureCount >= _failureThreshold)
        {
            // Trip the breaker
            _openedAt = DateTime.UtcNow;
        }
    }
}
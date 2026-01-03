using System.Threading;

namespace BackendMastery.ProdReadiness.GracefulDegradation.Infrastructure;

/// <summary>
/// Tracks system load heuristically.
///
/// WHY THIS EXISTS:
/// Graceful degradation must be driven
/// by real pressure signals.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents optional features from consuming
/// capacity needed by critical flows.
///
/// WHAT BREAKS IF MISUSED:
/// Static thresholds lead to false degradation.
/// </summary>
public sealed class LoadMonitor
{
    private int _inFlightRequests;

    public void Increment() => Interlocked.Increment(ref _inFlightRequests);
    public void Decrement() => Interlocked.Decrement(ref _inFlightRequests);

    public bool IsUnderStress()
    {
        // Simple heuristic for demo purposes
        return _inFlightRequests > 5;
    }
}
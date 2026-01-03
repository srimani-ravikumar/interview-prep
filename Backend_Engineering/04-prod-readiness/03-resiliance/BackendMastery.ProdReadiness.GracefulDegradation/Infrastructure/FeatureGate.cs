namespace BackendMastery.ProdReadiness.GracefulDegradation.Infrastructure;

/// <summary>
/// Determines which features are allowed under load.
///
/// WHY THIS EXISTS:
/// Not all features deserve equal survival priority.
///
/// WHAT PROBLEM THIS SOLVES:
/// Ensures critical paths survive stress.
///
/// WHAT BREAKS IF MISUSED:
/// Treating optional features as critical
/// causes revenue-impacting outages.
/// </summary>
public sealed class FeatureGate
{
    private readonly LoadMonitor _monitor;

    public FeatureGate(LoadMonitor monitor)
    {
        _monitor = monitor;
    }

    public bool AllowRecommendations()
        => !_monitor.IsUnderStress();

    public bool AllowReviews()
        => !_monitor.IsUnderStress();
}
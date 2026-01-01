namespace BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Infrastructure;

/// <summary>
/// Fallback mechanism for NON-CRITICAL data.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Metrics failure should NOT block business flow
///
/// USE CASE:
/// - Analytics
/// - Logging
///
/// KEY RULE:
/// ❗ Fail-safe is acceptable ONLY for non-critical data
/// </remarks>
public static class MetricsFallback
{
    public static void RecordFailure(string message)
    {
        // Fail-safe: best effort, never throws
        Console.WriteLine($"[METRICS FALLBACK] {message}");
    }
}
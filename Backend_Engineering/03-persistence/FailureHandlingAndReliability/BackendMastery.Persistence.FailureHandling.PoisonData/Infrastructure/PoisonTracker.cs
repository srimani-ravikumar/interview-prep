namespace BackendMastery.Persistence.FailureHandling.PoisonData.Infrastructure;

/// <summary>
/// Tracks repeated failures for the same data.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Same message failing repeatedly is a red flag
///
/// KEY RULE:
/// ❗ Detect poison data early
/// </remarks>
public class PoisonTracker
{
    private readonly Dictionary<string, int> _failures = new();
    private const int PoisonThreshold = 3;

    public bool RegisterFailure(string messageId)
    {
        _failures.TryGetValue(messageId, out int count);
        count++;
        _failures[messageId] = count;

        return count >= PoisonThreshold;
    }
}
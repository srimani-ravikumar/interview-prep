namespace BackendMastery.ProdReadiness.Fallbacks.Infrastructure;

/// <summary>
/// Simulates recommendation engine.
///
/// WHY THIS EXISTS:
/// Recommendations improve UX
/// but are not critical for purchase.
///
/// WHAT BREAKS IF MISUSED:
/// Blocking product views due to recommendations.
/// </summary>
public sealed class RecommendationClient
{
    public async Task<IReadOnlyList<string>> GetAsync(
        string productId,
        CancellationToken cancellationToken)
    {
        await Task.Delay(200, cancellationToken);

        // Simulate frequent failure
        throw new Exception("Recommendation engine down.");
    }
}
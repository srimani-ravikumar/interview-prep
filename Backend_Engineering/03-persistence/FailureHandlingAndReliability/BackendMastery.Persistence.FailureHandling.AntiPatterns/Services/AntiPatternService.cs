using BackendMastery.Persistence.FailureHandling.AntiPatterns.Infrastructure;

namespace BackendMastery.Persistence.FailureHandling.AntiPatterns.Services;

/// <summary>
/// Demonstrates common failure-handling anti-patterns.
/// </summary>
/// <remarks>
/// INTUITION:
/// - These patterns feel safe
/// - They are NOT
///
/// KEY RULE:
/// ❗ Avoid these in production systems
/// </remarks>
public class AntiPatternService
{
    private readonly UnreliableStore _store = new();

    // --------------------------------------------------
    // ANTI-PATTERN 1: Swallowing exceptions
    // --------------------------------------------------
    public void SwallowFailure(string data)
    {
        try
        {
            _store.Save(data);
        }
        catch
        {
            // ❌ Failure hidden
            Console.WriteLine("Swallowed exception and continued");
        }
    }

    // --------------------------------------------------
    // ANTI-PATTERN 2: Infinite retry
    // --------------------------------------------------
    public void InfiniteRetry(string data)
    {
        while (true)
        {
            try
            {
                _store.Save(data);
                return;
            }
            catch
            {
                Console.WriteLine("Retrying forever...");
            }
        }
    }

    // --------------------------------------------------
    // ANTI-PATTERN 3: Fake success
    // --------------------------------------------------
    public void PretendSuccess(string data)
    {
        try
        {
            _store.Save(data);
        }
        catch
        {
            // ❌ Lying to caller
            Console.WriteLine("Failed, but reporting success anyway");
        }

        Console.WriteLine("Operation reported as SUCCESS");
    }
}
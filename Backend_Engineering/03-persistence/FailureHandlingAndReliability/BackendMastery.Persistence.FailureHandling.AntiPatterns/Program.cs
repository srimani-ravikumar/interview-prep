using BackendMastery.Persistence.FailureHandling.AntiPatterns.Services;

namespace BackendMastery.Persistence.FailureHandling.AntiPatterns;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== FAILURE HANDLING ANTI-PATTERNS DEMO ===\n");

        var service = new AntiPatternService();

        // --------------------------------------------------
        // SCENARIO 1: Swallowed exception
        // --------------------------------------------------
        Console.WriteLine("SCENARIO 1: Swallowing exceptions\n");
        service.SwallowFailure("DATA-1");

        // --------------------------------------------------
        // SCENARIO 2: Pretend success
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 2: Fake success\n");
        service.PretendSuccess("DATA-2");

        // --------------------------------------------------
        // SCENARIO 3: Infinite retry (INTENTIONALLY STOPPED)
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 3: Infinite retry (manual stop)\n");
        Console.WriteLine("This will loop forever — stop manually\n");

        // Uncomment to experience the pain
        service.InfiniteRetry("DATA-3");

        Console.WriteLine("=== DEMO COMPLETE ===");
    }
}
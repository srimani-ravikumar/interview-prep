using BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Domain;
using BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Infrastructure;
using BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs.Services;

namespace BackendMastery.Persistence.FailureHandling.ConsistencyTradeoffs;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== CONSISTENCY vs AVAILABILITY DEMO ===\n");

        var store = new AccountStore();
        store.Add(new Account("A1", 1000));

        var service = new AccountService(store);

        // --------------------------------------------------
        // SCENARIO 1: Strong consistency read
        // --------------------------------------------------
        Console.WriteLine("SCENARIO 1: Strong consistency\n");

        TryStrong(service);

        // --------------------------------------------------
        // SCENARIO 2: Availability-first read
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 2: High availability\n");

        service.ShowBalance_HighAvailability("A1");

        // --------------------------------------------------
        // SCENARIO 3: Repeated attempts under partition
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 3: Repeated strong reads\n");

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Attempt {i}:");
            TryStrong(service);
            Console.WriteLine();
        }

        Console.WriteLine("=== DEMO COMPLETE ===");
    }

    private static void TryStrong(AccountService service)
    {
        try
        {
            service.ShowBalance_StrongConsistency("A1");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"BLOCKED: {ex.Message}");
        }
    }
}
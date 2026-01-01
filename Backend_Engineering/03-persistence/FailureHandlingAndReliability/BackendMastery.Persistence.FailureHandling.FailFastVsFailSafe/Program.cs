using BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Domain;
using BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Infrastructure;
using BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe.Services;

namespace BackendMastery.Persistence.FailureHandling.FailFastVsFailSafe;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== FAIL-FAST vs FAIL-SAFE DEMO ===\n");

        var store = new InventoryStore();
        store.Add(new InventoryItem("ITEM-1", 10));

        var service = new InventoryService(store);

        // --------------------------------------------------
        // SCENARIO 1: Normal operation (no failures)
        // --------------------------------------------------
        Console.WriteLine("SCENARIO 1: Normal inventory reservation\n");

        TryReserve(service, "ITEM-1", 2);

        // --------------------------------------------------
        // SCENARIO 2: Transient persistence failure
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 2: Simulated persistence failure\n");

        // Run multiple times to probabilistically hit failure
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Attempt {i}:");
            TryReserve(service, "ITEM-1", 1);
            Console.WriteLine();
        }

        // --------------------------------------------------
        // SCENARIO 3: Business rule failure (insufficient stock)
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 3: Business rule violation\n");

        TryReserve(service, "ITEM-1", 100);

        Console.WriteLine("\n=== DEMO COMPLETE ===");
    }

    private static void TryReserve(
        InventoryService service,
        string productId,
        int quantity)
    {
        try
        {
            service.ReserveStock(productId, quantity);
            Console.WriteLine("Result: SUCCESS\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Result: FAILURE → {ex.Message}\n");
        }
    }
}
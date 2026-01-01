using BackendMastery.Persistence.FailureHandling.Compensation.Services;

namespace BackendMastery.Persistence.FailureHandling.Compensation;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== PARTIAL FAILURE & COMPENSATION DEMO ===\n");

        var service = new OrderPlacementService();

        // --------------------------------------------------
        // SCENARIO 1: All steps succeed
        // --------------------------------------------------
        Console.WriteLine("SCENARIO 1: Clean success\n");
        service.PlaceOrder(500);

        // --------------------------------------------------
        // SCENARIO 2: Inventory fails after payment
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 2: Partial failure (inventory)\n");

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Attempt {i}:");
            service.PlaceOrder(750);
            Console.WriteLine();
        }

        // --------------------------------------------------
        // SCENARIO 3: Repeated partial failures
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 3: Repeated compensation\n");

        for (int i = 1; i <= 2; i++)
        {
            service.PlaceOrder(1000);
            Console.WriteLine();
        }

        Console.WriteLine("=== DEMO COMPLETE ===");
    }
}
using BackendMastery.Persistence.FailureHandling.RetryStrategies.Services;

namespace BackendMastery.Persistence.FailureHandling.RetryStrategies;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== RETRY STRATEGIES DEMO ===\n");

        var service = new OrderService();

        // --------------------------------------------------
        // SCENARIO 1: Successful order without retries
        // --------------------------------------------------
        Console.WriteLine("SCENARIO 1: Clean success\n");
        TryCreate(service, 100);

        // --------------------------------------------------
        // SCENARIO 2: Transient failures with recovery
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 2: Transient failures\n");

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Run {i}:");
            TryCreate(service, 150);
            Console.WriteLine();
        }

        // --------------------------------------------------
        // SCENARIO 3: Permanent failure (no retries)
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 3: Permanent failure\n");
        TryCreate(service, 200);

        // --------------------------------------------------
        // SCENARIO 4: Retry limit exceeded
        // --------------------------------------------------
        Console.WriteLine("\nSCENARIO 4: Retry limit exceeded\n");

        try
        {
            service.CreateOrder(300);
        }
        catch
        {
            Console.WriteLine("Order failed after retries");
        }

        Console.WriteLine("\n=== DEMO COMPLETE ===");
    }

    private static void TryCreate(OrderService service, decimal amount)
    {
        try
        {
            service.CreateOrder(amount);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Final Result: FAILURE → {ex.Message}");
        }
    }
}
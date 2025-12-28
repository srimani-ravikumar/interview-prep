using BackendMastery.Persistence.Transactions.Idempotency.Services;

namespace BackendMastery.Persistence.Transactions.Idempotency;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Idempotency + Transaction Demo ===\n");

        var service = new OrderService();
        var key = "checkout-req-789"; // client-generated

        Console.WriteLine("First attempt:");
        service.CreateOrder(key, 1200);

        Console.WriteLine("\nRetry attempt:");
        service.CreateOrder(key, 1200);

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
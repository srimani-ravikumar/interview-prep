using BackendMastery.Persistence.Transactions.AntiPatterns.Services;

namespace BackendMastery.Persistence.Transactions.AntiPatterns;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Transaction Anti-Patterns Demo ===\n");

        var service = new CheckoutService();

        try
        {
            service.Checkout();
        }
        catch
        {
            Console.WriteLine("Checkout failed — but damage may already be done");
        }

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
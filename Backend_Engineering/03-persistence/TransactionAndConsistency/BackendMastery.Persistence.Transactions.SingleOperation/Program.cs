using BackendMastery.Persistence.Transactions.SingleOperation.Services;

namespace BackendMastery.Persistence.Transactions.SingleOperation;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Single Operation Transaction Demo ===\n");

        var service = new AccountService();

        try
        {
            service.CreateAccount(1000);
        }
        catch
        {
            Console.WriteLine("Operation failed.");
        }

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
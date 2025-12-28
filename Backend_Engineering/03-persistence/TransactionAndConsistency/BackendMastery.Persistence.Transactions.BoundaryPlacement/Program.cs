using BackendMastery.Persistence.Transactions.BoundaryPlacement.Controllers;
using BackendMastery.Persistence.Transactions.BoundaryPlacement.Services;

namespace BackendMastery.Persistence.Transactions.BoundaryPlacement;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Transaction Boundary Placement Demo ===\n");

        Console.WriteLine("✅ Correct: Transaction in Service");
        var service = new TransferService();

        try
        {
            service.ExecuteTransfer();
        }
        catch
        {
            Console.WriteLine("Transfer failed safely");
        }

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
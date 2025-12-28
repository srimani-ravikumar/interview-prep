using BackendMastery.Persistence.Transactions.MultiStepUseCase.Domain;
using BackendMastery.Persistence.Transactions.MultiStepUseCase.Services;

namespace BackendMastery.Persistence.Transactions.MultiStepUseCase;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Multi-Step Use Case Transaction Demo ===\n");

        var account = new Account(1000);
        var service = new TransferService();

        try
        {
            service.Transfer(account, 300);
        }
        catch
        {
            Console.WriteLine("Transfer failed — state rolled back");
        }

        Console.WriteLine($"\nFinal Balance: {account.Balance}");
        Console.WriteLine("\n=== Demo Complete ===");
    }
}
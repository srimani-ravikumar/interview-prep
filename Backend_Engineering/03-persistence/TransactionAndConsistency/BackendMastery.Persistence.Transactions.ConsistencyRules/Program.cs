using BackendMastery.Persistence.Transactions.ConsistencyRules.Domain;
using BackendMastery.Persistence.Transactions.ConsistencyRules.Services;

namespace BackendMastery.Persistence.Transactions.ConsistencyRules;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Consistency Rules Enforcement Demo ===\n");

        var account = new Account(500);
        var service = new WithdrawalService();

        try
        {
            service.Withdraw(account, 700); // violates invariant
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Operation blocked: {ex.Message}");
        }

        Console.WriteLine($"\nFinal Balance: {account.Balance}");
        Console.WriteLine("\n=== Demo Complete ===");
    }
}
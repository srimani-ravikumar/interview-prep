using BackendMastery.Persistence.ORM.QueryShaping.Infrastructure;

namespace BackendMastery.Persistence.ORM.QueryShaping;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Query Shaping Demo ===\n");

        var context = new FakeDbContext();

        Console.WriteLine("---- ENTITY LOAD ----");
        var customer = context.LoadFullCustomer(1);
        Console.WriteLine($"Customer: {customer.Name}");

        Console.WriteLine("\n---- PROJECTION LOAD ----");
        var summary = context.LoadCustomerSummary(1);
        Console.WriteLine($"Customer: {summary.Name}");

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
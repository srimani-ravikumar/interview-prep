using BackendMastery.Persistence.ORM.ReadWriteBehavior.Infrastructure;

namespace BackendMastery.Persistence.ORM.ReadWriteBehavior;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Read vs Write Query Demo ===\n");

        var context = new FakeDbContext();

        Console.WriteLine("---- READ-ONLY SCENARIO ----");
        var readOrder = context.GetOrderForRead(1);
        Console.WriteLine($"Order status (read): {readOrder.Status}");

        Console.WriteLine("\n---- WRITE SCENARIO ----");
        var writeOrder = context.GetOrderForUpdate(2);
        writeOrder.MarkAsShipped();

        context.SaveChanges();

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
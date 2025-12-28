using BackendMastery.Persistence.ORM.ChangeTracking.Infrastructure;

namespace BackendMastery.Persistence.ORM.ChangeTracking;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Change Tracking Demo ===\n");

        var context = new FakeDbContext();

        var product = context.GetProductById(1);

        Console.WriteLine("\nModifying entity in memory...");
        product.Rename("Mechanical Keyboard");
        product.ChangePrice(1500);

        Console.WriteLine("\nCommitting changes...");
        context.SaveChanges();

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
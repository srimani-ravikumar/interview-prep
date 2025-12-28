using BackendMastery.Persistence.ORM.LoadingStrategies.Infrastructure;

namespace BackendMastery.Persistence.ORM.LoadingStrategies;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Lazy vs Eager Loading Demo ===\n");

        var context = new FakeDbContext();

        Console.WriteLine("---- LAZY LOADING ----");
        var lazyOrder = context.GetOrderLazy(1);

        Console.WriteLine("Accessing Items...");
        foreach (var item in lazyOrder.Items)
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("\n---- EAGER LOADING ----");
        var eagerOrder = context.GetOrderEager(2);

        Console.WriteLine("Accessing Items...");
        foreach (var item in eagerOrder.Items)
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
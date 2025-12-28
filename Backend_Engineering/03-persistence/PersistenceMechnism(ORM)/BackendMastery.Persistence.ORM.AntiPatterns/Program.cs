using BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

namespace BackendMastery.Persistence.ORM.AntiPatterns;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== ORM Anti-Patterns Demo ===\n");

        var repository = new OrderRepository();
        var service = new OrderService(repository);

        service.PayOrder(1);

        Console.WriteLine("\n=== Demo Complete ===");
    }
}
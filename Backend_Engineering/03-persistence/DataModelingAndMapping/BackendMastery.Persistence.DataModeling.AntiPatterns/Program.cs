namespace BackendMastery.Persistence.DataModeling.AntiPatterns;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Anti-Patterns Demo ===");
        Console.WriteLine();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            Amount = 1000
        };

        // No protection, no invariants
        order.ApplyDiscount(1500); // ❌ Negative amount allowed

        Console.WriteLine($"Order Amount After Discount: {order.Amount}");
        Console.WriteLine();

        order.SaveToDatabase();
        order.SendEmail();

        Console.WriteLine("=== Demo Complete ===");
    }
}
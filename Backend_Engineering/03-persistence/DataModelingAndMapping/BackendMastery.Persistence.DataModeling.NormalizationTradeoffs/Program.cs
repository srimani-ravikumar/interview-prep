using BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Domain;
using BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Mapping;

namespace BackendMastery.Persistence.DataModeling.NormalizationTradeoffs;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Normalization vs Pragmatism Demo ===");
        Console.WriteLine();

        var order = new Order(new OrderId(Guid.NewGuid()));
        order.AddItem("SKU-1", 100, 2);
        order.AddItem("SKU-2", 50, 1);

        var (_, items) = OrderMapper.ToNormalized(order);
        var summary = OrderMapper.ToSummary(order);

        Console.WriteLine($"Normalized Items Count: {items.Count}");
        Console.WriteLine($"Denormalized Total: {summary.TotalAmount}");
        Console.WriteLine($"Denormalized Item Count: {summary.ItemCount}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
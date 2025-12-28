using BackendMastery.Persistence.DataModeling.SchemaEvolution.Mapping;
using BackendMastery.Persistence.DataModeling.SchemaEvolution.Storage;

namespace BackendMastery.Persistence.DataModeling.SchemaEvolution;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Schema Evolution Demo ===");
        Console.WriteLine();

        // Old data (already in DB)
        var oldRecord = new OrderRecordV1
        {
            Id = Guid.NewGuid(),
            Amount = 1000
        };

        // New data
        var newRecord = new OrderRecordV2
        {
            Id = Guid.NewGuid(),
            Amount = 1000,
            DiscountAmount = 100
        };

        var oldOrder = OrderMapper.FromV1(oldRecord);
        var newOrder = OrderMapper.FromV2(newRecord);

        Console.WriteLine($"Old Order Final Amount: {oldOrder.FinalAmount}");
        Console.WriteLine($"New Order Final Amount: {newOrder.FinalAmount}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
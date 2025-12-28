using BackendMastery.Persistence.DataModeling.Aggregates.Domain;
using BackendMastery.Persistence.DataModeling.Aggregates.Mapping;

namespace BackendMastery.Persistence.DataModeling.Aggregates;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Aggregate Boundary Demo ===");
        Console.WriteLine();

        var order = new Order(new OrderId(Guid.NewGuid()));

        // Only aggregate root can mutate internal state
        order.AddItem("SKU-1", 100, 2);
        order.AddItem("SKU-2", 50, 1);

        Console.WriteLine($"Order Total: {order.TotalAmount}");
        Console.WriteLine($"Items Count: {order.Items.Count}");
        Console.WriteLine();

        // External code CANNOT do this:
        // order.Items.Add(...)  ❌

        var (orderRecord, itemRecords) = OrderMapper.ToStorage(order);

        Console.WriteLine("Storage Representation:");
        Console.WriteLine($"OrderRecord.TotalAmount: {orderRecord.TotalAmount}");
        Console.WriteLine($"OrderItemRecords.Count: {itemRecords.Count}");

        Console.WriteLine();
        Console.WriteLine("=== Demo Complete ===");
    }
}
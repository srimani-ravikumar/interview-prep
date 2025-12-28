using BackendMastery.Persistence.DataModeling.EntityIdentity.Domain;
using BackendMastery.Persistence.DataModeling.EntityIdentity.Mapping;
using BackendMastery.Persistence.DataModeling.EntityIdentity.Storage;

namespace BackendMastery.Persistence.DataModeling.EntityIdentity;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Entity Identity & Lifecycle Demo ===");
        Console.WriteLine();

        // ---------------------------------------
        // 1. Create identity explicitly
        // ---------------------------------------
        var orderId = new OrderId(Guid.NewGuid());

        var order = new Order(orderId, 500);

        Console.WriteLine($"Created Order");
        Console.WriteLine($"Id: {order.Id}");
        Console.WriteLine($"Amount: {order.Amount}");
        Console.WriteLine();

        // ---------------------------------------
        // 2. Mutate entity (identity remains same)
        // ---------------------------------------
        order.UpdateAmount(750);

        Console.WriteLine("Updated Order");
        Console.WriteLine($"Id (unchanged): {order.Id}");
        Console.WriteLine($"Amount (changed): {order.Amount}");
        Console.WriteLine();

        // ---------------------------------------
        // 3. Map to storage
        // ---------------------------------------
        OrderRecord record = OrderMapper.ToRecord(order);

        Console.WriteLine("Stored Record");
        Console.WriteLine($"Id: {record.Id}");
        Console.WriteLine($"Amount: {record.Amount}");
        Console.WriteLine($"UpdatedAtUtc: {record.UpdatedAtUtc}");
        Console.WriteLine();

        // ---------------------------------------
        // 4. Rehydrate from storage
        // ---------------------------------------
        var rehydrated = OrderMapper.ToDomain(record);

        Console.WriteLine("Rehydrated Domain Order");
        Console.WriteLine($"Id: {rehydrated.Id}");
        Console.WriteLine($"Amount: {rehydrated.Amount}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
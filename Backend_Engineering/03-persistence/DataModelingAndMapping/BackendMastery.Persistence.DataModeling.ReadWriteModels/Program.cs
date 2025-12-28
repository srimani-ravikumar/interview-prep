using BackendMastery.Persistence.DataModeling.ReadWriteModels.Domain;
using BackendMastery.Persistence.DataModeling.ReadWriteModels.Mapping;

namespace BackendMastery.Persistence.DataModeling.ReadWriteModels;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Read vs Write Model Demo ===");
        Console.WriteLine();

        var order = new Order(new OrderId(Guid.NewGuid()));
        order.AddItem("SKU-1", 100, 2);
        order.AddItem("SKU-2", 50, 1);

        Console.WriteLine($"Write Model Total: {order.TotalAmount}");

        var readModel = OrderProjection.Project(order);

        Console.WriteLine($"Read Model Total: {readModel.TotalAmount}");
        Console.WriteLine($"Read Model Item Count: {readModel.ItemCount}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
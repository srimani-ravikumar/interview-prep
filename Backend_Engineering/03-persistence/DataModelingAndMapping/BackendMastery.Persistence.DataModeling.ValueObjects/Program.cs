using BackendMastery.Persistence.DataModeling.ValueObjects.Domain;
using BackendMastery.Persistence.DataModeling.ValueObjects.Mapping;

namespace BackendMastery.Persistence.DataModeling.ValueObjects;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Value Objects Demo ===");
        Console.WriteLine();

        var order = new Order(
            new OrderId(Guid.NewGuid()),
            new Money(500, "USD"),
            new Address("Street 1", "NY", "USA")
        );

        Console.WriteLine($"Order Total: {order.Total}");
        Console.WriteLine($"Shipping City: {order.ShippingAddress.City}");
        Console.WriteLine();

        // Replace value object entirely
        order.UpdateAddress(new Address("Street 2", "LA", "USA"));

        Console.WriteLine("Updated Address:");
        Console.WriteLine(order.ShippingAddress.City);
        Console.WriteLine();

        var record = OrderMapper.ToRecord(order);
        var rehydrated = OrderMapper.ToDomain(record);

        Console.WriteLine("Rehydrated Order Total:");
        Console.WriteLine(rehydrated.Total);
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
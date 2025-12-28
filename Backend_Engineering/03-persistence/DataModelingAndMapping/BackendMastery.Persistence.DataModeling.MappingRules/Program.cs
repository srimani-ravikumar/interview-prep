using BackendMastery.Persistence.DataModeling.MappingRules.Domain;
using BackendMastery.Persistence.DataModeling.MappingRules.Mapping;

namespace BackendMastery.Persistence.DataModeling.MappingRules;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Mapping Rules Demo ===");
        Console.WriteLine();

        var order = new Order(
            new OrderId(Guid.NewGuid()),
            new Money(1200, "USD"),
            new Address("Street 1", "NY", "USA")
        );

        var (orderRecord, addressRecord) = OrderMapper.ToStorage(order);

        Console.WriteLine("Storage Shapes:");
        Console.WriteLine($"OrderRecord.Amount: {orderRecord.Amount}");
        Console.WriteLine($"AddressRecord.City: {addressRecord.City}");
        Console.WriteLine();

        var rehydrated = OrderMapper.ToDomain(orderRecord, addressRecord);

        Console.WriteLine("Rehydrated Domain:");
        Console.WriteLine($"Total: {rehydrated.Total.Amount} {rehydrated.Total.Currency}");
        Console.WriteLine($"City: {rehydrated.ShippingAddress.City}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
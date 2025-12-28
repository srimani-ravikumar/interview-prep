using BackendMastery.Persistence.Transactions.ConsistencyModels.Domain;
using BackendMastery.Persistence.Transactions.ConsistencyModels.Services;

namespace BackendMastery.Persistence.Transactions.ConsistencyModels;

internal class Program
{
    private static async Task Main()
    {
        Console.WriteLine("=== Consistency Models Demo ===");
        Console.WriteLine();

        var service = new OrderStatusService();
        var order = new Order();

        service.PlaceOrder(order);

        Console.WriteLine("Immediately after placing order:");
        Console.WriteLine($"Strong Read: {service.GetStrongStatus(order.Id)}");
        Console.WriteLine($"Eventual Read: {service.GetEventualStatus(order.Id)}");

        Console.WriteLine();
        Console.WriteLine("Waiting for eventual consistency...");
        await Task.Delay(1500);

        Console.WriteLine($"Eventual Read (after delay): {service.GetEventualStatus(order.Id)}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
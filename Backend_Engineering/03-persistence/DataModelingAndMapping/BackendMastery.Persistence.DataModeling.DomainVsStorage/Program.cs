using BackendMastery.Persistence.DataModeling.DomainVsStorage.Domain;
using BackendMastery.Persistence.DataModeling.DomainVsStorage.Mapping;
using BackendMastery.Persistence.DataModeling.DomainVsStorage.Storage;

namespace BackendMastery.Persistence.DataModeling.DomainVsStorage;

/// <summary>
/// Entry point for the console application.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This is the composition root for this demo
/// - Demonstrates:
///   1. Domain model creation
///   2. Mapping to storage model
///   3. Mapping back to domain
///
/// IMPORTANT:
/// - Domain does not know storage exists
/// - Storage does not know business rules exist
/// - Program.cs wires everything together
/// </remarks>
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Domain vs Storage Model Demo ===");
        Console.WriteLine();

        // ---------------------------------------
        // 1. Create DOMAIN object (business truth)
        // ---------------------------------------

        var orderId = Guid.NewGuid();
        var domainOrder = new Order(orderId, amount: 1500);

        Console.WriteLine("Domain Order:");
        Console.WriteLine($"Id: {domainOrder.Id}");
        Console.WriteLine($"Amount: {domainOrder.Amount}");
        Console.WriteLine($"IsPriority (derived): {domainOrder.IsPriority}");
        Console.WriteLine();

        // ---------------------------------------
        // 2. Map DOMAIN → STORAGE
        // ---------------------------------------

        OrderRecord record = OrderMapper.ToRecord(domainOrder);

        Console.WriteLine("Storage Record:");
        Console.WriteLine($"Id: {record.Id}");
        Console.WriteLine($"Amount: {record.Amount}");
        Console.WriteLine($"CreatedAtUtc: {record.CreatedAtUtc}");
        Console.WriteLine($"Status: {record.Status}");
        Console.WriteLine();

        // ---------------------------------------
        // 3. Simulate reading from storage
        // ---------------------------------------
        // (Imagine this came from a database)

        var loadedRecord = new OrderRecord
        {
            Id = record.Id,
            Amount = record.Amount,
            CreatedAtUtc = record.CreatedAtUtc,
            Status = record.Status
        };

        // ---------------------------------------
        // 4. Map STORAGE → DOMAIN
        // ---------------------------------------

        Order rehydratedDomainOrder = OrderMapper.ToDomain(loadedRecord);

        Console.WriteLine("Rehydrated Domain Order:");
        Console.WriteLine($"Id: {rehydratedDomainOrder.Id}");
        Console.WriteLine($"Amount: {rehydratedDomainOrder.Amount}");
        Console.WriteLine($"IsPriority (re-derived): {rehydratedDomainOrder.IsPriority}");
        Console.WriteLine();

        Console.WriteLine("=== Demo Complete ===");
    }
}
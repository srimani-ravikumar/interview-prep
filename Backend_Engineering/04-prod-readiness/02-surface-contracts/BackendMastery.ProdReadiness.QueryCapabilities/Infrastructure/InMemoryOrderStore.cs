namespace BackendMastery.ProdReadiness.QueryCapabilities.Infrastructure;

/// <summary>
/// INTUITION:
/// This class simulates a large, read-heavy data store.
///
/// USE CASE:
/// - Demo query behavior (filtering, sorting, pagination)
/// - Reproduce scale-related issues without a real DB
///
/// PRODUCTION ANALOG:
/// - Read replica
/// - Query-optimized projection
///
/// FAILURE MODE:
/// - Treating this like a repository abstraction
/// - Hiding query behavior behind methods
/// </summary>
public static class InMemoryOrderStore
{
    // 1. Data Persistence:
    // Using 'static readonly' with a pre-defined capacity ensures memory is allocated 
    // efficiently once and shared across all API requests during the app lifecycle.
    private static readonly List<OrderRecord> _orders = GenerateOrders();

    /// <summary>
    /// The "Magic" of this class: AsQueryable().
    /// </summary>
    public static IQueryable<OrderRecord> Query()
        // .AsQueryable() allows the Controller to use LINQ (Where, OrderBy, Skip, Take)
        // as if it were writing SQL. This is the key to 'Deferred Execution'.
        => _orders.AsQueryable();

    private static List<OrderRecord> GenerateOrders()
    {
        // 1. Efficiency: Pre-allocate list capacity to avoid expensive 'resize' operations 
        // as we add 10,000 items.
        var list = new List<OrderRecord>(capacity: 10_000);

        // 2. Determinism: Using a fixed seed (42) ensures the data is identical 
        // every time the app starts—crucial for debugging query results.
        var random = new Random(42);

        var baseTime = DateTime.UtcNow;

        for (int i = 1; i <= 10_000; i++)
        {
            list.Add(new OrderRecord
            {
                OrderId = Guid.NewGuid(),
                // 3. Modulo Distribution: Ensures a predictable mix of "Created", 
                // "Paid", and "Shipped" statuses for testing filters.
                Status = (i % 3) switch
                {
                    0 => "Created",
                    1 => "Paid",
                    _ => "Shipped"
                },
                Amount = random.Next(50, 5000),
                // 4. Chronological spread: Subtracting minutes ensures 'CreatedAtUtc' 
                // is always different, which is vital for testing sorting and pagination.
                CreatedAtUtc = baseTime.AddMilliseconds(-i) // ← IMPORTANT
            });
        }

        return list;
    }

    /// <summary>
    /// The "Database Entity" analog.
    /// </summary>
    public sealed class OrderRecord
    {
        // 'init' only properties reinforce that this data is Read-Only 
        // from the perspective of a Query capability.
        public Guid OrderId { get; init; }
        public string Status { get; init; } = string.Empty;
        public decimal Amount { get; init; }
        public DateTime CreatedAtUtc { get; init; }
    }
}
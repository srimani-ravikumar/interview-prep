using BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

namespace BackendMastery.Persistence.ORM.AntiPatterns;

/// <summary>
/// ❗ Intentionally naive fake ORM context.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This simulates how ORMs are often *misused*
/// - It is NOT a good implementation
///
/// USE CASE:
/// - Demonstrate anti-patterns like:
///   - DbContext in controllers
///   - IQueryable leakage
///
/// KEY RULE:
/// ❗ This exists ONLY for teaching purposes
/// </remarks>
public class FakeDbContext
{
    // Simulated DbSet<Order>
    public IQueryable<Order> Orders => _orders.AsQueryable();

    private readonly List<Order> _orders = new()
    {
        new Order(1),
        new Order(2),
        new Order(3)
    };

    /// <summary>
    /// Simulates committing changes to the database.
    /// </summary>
    /// <remarks>
    /// INTUITION:
    /// - ORMs track changes and persist at commit
    ///
    /// KEY RULE:
    /// ❗ SaveChanges should live behind a boundary
    /// </remarks>
    public void SaveChanges()
    {
        Console.WriteLine("Persisting changes to database...");
    }
}
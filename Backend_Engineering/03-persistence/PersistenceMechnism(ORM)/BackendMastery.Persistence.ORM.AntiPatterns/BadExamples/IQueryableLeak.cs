using BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

namespace BackendMastery.Persistence.ORM.AntiPatterns.BadExamples;

/// <summary>
/// ❌ Anti-pattern: Returning IQueryable.
/// </summary>
/// <remarks>
/// WHY THIS IS BAD:
/// - Query execution happens unpredictably
/// - Performance characteristics leak upward
/// - ORM-specific behavior spreads everywhere
///
/// ROOT CAUSE:
/// - Leaking infrastructure into application logic
/// </remarks>
public class OrderRepository
{
    public IQueryable<Order> GetOrders()
    {
        return new List<Order>().AsQueryable();
    }
}
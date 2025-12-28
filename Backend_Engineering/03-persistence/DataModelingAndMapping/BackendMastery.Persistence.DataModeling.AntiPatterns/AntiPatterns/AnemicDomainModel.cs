namespace BackendMastery.Persistence.DataModeling.AntiPatterns;

/// <summary>
/// ❌ ANTI-PATTERN: Anemic Domain Model
/// </summary>
/// <remarks>
/// INTUITION:
/// - Looks clean at first
/// - Feels "simple"
/// - But pushes all logic outside the model
///
/// USE CASE (WRONG):
/// - CRUD-heavy applications
/// - Table-first thinking
///
/// WHY THIS IS BAD:
/// - No invariants are protected
/// - Logic spreads across services
/// - Easy to misuse incorrectly
///
/// KEY RULE:
/// ❗ If a domain object has no behavior, it is not a domain model.
/// </remarks>
public class Order
{
    // Just data, no rules
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
}

/// <summary>
/// Logic lives outside the model ❌
/// </summary>
public static class OrderService
{
    public static decimal ApplyDiscount(Order order, decimal discount)
    {
        // No validation, no invariant
        order.Amount -= discount;
        return order.Amount;
    }
}
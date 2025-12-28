namespace BackendMastery.Persistence.ORM.AntiPatterns.BadExamples;

/// <summary>
/// ❌ Anti-pattern: Controller using ORM directly.
/// </summary>
/// <remarks>
/// WHY THIS IS BAD:
/// - Controller now owns persistence logic
/// - Business rules and storage are mixed
/// - Hard to test
/// - Hard to change ORM later
///
/// ROOT CAUSE:
/// - Treating ORM as a query helper
/// </remarks>
public class OrdersController
{
    private readonly FakeDbContext _context = new();

    public void PayOrder(int orderId)
    {
        var order = _context.Orders.First(o => o.Id == orderId);
        order.MarkAsPaid();

        _context.SaveChanges();
    }
}
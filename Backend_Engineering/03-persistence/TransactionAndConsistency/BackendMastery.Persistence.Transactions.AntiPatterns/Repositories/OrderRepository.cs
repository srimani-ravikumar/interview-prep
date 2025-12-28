using BackendMastery.Persistence.Transactions.AntiPatterns.Infrastructure;

namespace BackendMastery.Persistence.Transactions.AntiPatterns.Repositories;

/// <summary>
/// Repository with hidden transaction.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Repository tries to be "safe"
/// - Creates nested transaction illusion
///
/// KEY RULE:
/// ❌ Nested transactions rarely behave as expected
/// </remarks>
public class OrderRepository
{
    private readonly TransactionManager _tx = new();
    private readonly FakeDatabase _db = new();

    public void SaveOrder()
    {
        _tx.Begin();
        _db.Save("Order");
        _tx.Commit();
    }
}
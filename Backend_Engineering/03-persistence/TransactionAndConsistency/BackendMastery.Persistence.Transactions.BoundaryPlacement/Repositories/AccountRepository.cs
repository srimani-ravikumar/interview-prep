using BackendMastery.Persistence.Transactions.BoundaryPlacement.Infrastructure;

namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Repositories;

/// <summary>
/// Repository with hidden transaction (ANTI-PATTERN).
/// </summary>
/// <remarks>
/// INTUITION:
/// - Repository tries to be "helpful"
/// - But it does not know the full use case
///
/// KEY RULE:
/// ❌ Repositories must NOT own transactions
/// </remarks>
public class AccountRepository
{
    private readonly FakeDatabase _db = new();
    private readonly TransactionManager _tx = new();

    public void SaveAccount()
    {
        _tx.Begin();
        _db.Save("Account");
        _tx.Commit();
    }

    public void SaveLedger()
    {
        _tx.Begin();
        _db.Save("LedgerEntry");
        _tx.Commit();
    }
}
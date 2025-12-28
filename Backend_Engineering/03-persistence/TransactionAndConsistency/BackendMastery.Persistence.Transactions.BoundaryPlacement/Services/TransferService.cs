using BackendMastery.Persistence.Transactions.BoundaryPlacement.Infrastructure;
using BackendMastery.Persistence.Transactions.BoundaryPlacement.Repositories;

namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Services;

/// <summary>
/// Use-case service with correct transaction boundary.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Service understands the business flow
/// - Owns correctness
///
/// USE CASE:
/// - Money transfer
///
/// KEY RULE:
/// ✅ Transaction belongs to the service layer
/// </remarks>
public class TransferService
{
    private readonly TransactionManager _tx = new();
    private readonly FakeDatabase _db = new();

    public void ExecuteTransfer()
    {
        _tx.Begin();

        try
        {
            _db.Save("Account");
            _db.Save("LedgerEntry");

            // Uncomment to simulate failure
            // throw new Exception("Ledger write failed");

            _tx.Commit();
        }
        catch
        {
            _tx.Rollback();
            throw;
        }
    }
}
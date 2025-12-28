using BackendMastery.Persistence.Transactions.BoundaryPlacement.Infrastructure;
using BackendMastery.Persistence.Transactions.BoundaryPlacement.Services;

namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Controllers;

/// <summary>
/// Controller managing transactions (BAD PRACTICE).
/// </summary>
/// <remarks>
/// INTUITION:
/// - Controller should handle I/O
/// - Not business correctness
///
/// KEY RULE:
/// ❌ Controllers should not manage transactions
/// </remarks>
public class TransferController
{
    private readonly TransactionManager _tx = new();
    private readonly TransferService _service = new();

    public void Transfer()
    {
        _tx.Begin();

        try
        {
            _service.ExecuteTransfer();
            _tx.Commit();
        }
        catch
        {
            _tx.Rollback();
            throw;
        }
    }
}
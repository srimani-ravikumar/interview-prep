namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Infrastructure;

/// <summary>
/// Centralized transaction manager.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Transaction is a boundary, not a side-effect
///
/// USE CASE:
/// - Group multiple writes
///
/// KEY RULE:
/// ❗ Transaction must be controlled at use-case level
/// </remarks>
public class TransactionManager
{
    public void Begin() => Console.WriteLine("BEGIN TRANSACTION");
    public void Commit() => Console.WriteLine("COMMIT TRANSACTION");
    public void Rollback() => Console.WriteLine("ROLLBACK TRANSACTION");
}
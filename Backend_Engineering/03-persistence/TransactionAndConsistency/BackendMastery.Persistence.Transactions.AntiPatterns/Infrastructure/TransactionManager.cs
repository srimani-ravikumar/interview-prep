namespace BackendMastery.Persistence.Transactions.AntiPatterns.Infrastructure;

/// <summary>
/// Simulates transaction lifecycle.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Transactions lock resources
/// - The longer they live, the more damage they cause
///
/// KEY RULE:
/// ❗ Transactions should be short-lived
/// </remarks>
public class TransactionManager
{
    public void Begin() => Console.WriteLine("BEGIN TRANSACTION");
    public void Commit() => Console.WriteLine("COMMIT TRANSACTION");
    public void Rollback() => Console.WriteLine("ROLLBACK TRANSACTION");
}
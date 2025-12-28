namespace BackendMastery.Persistence.Transactions.MultiStepUseCase.Infrastructure;

/// <summary>
/// Simulates a database transaction across multiple operations.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Database transaction groups multiple writes
/// - Either all commit or all rollback
///
/// USE CASE:
/// - Multi-step business operation
///
/// KEY RULE:
/// ❗ Transaction boundary must wrap the entire use case
/// </remarks>
public class FakeDatabase
{
    public void BeginTransaction()
    {
        Console.WriteLine("BEGIN TRANSACTION");
    }

    public void Commit()
    {
        Console.WriteLine("COMMIT TRANSACTION");
    }

    public void Rollback()
    {
        Console.WriteLine("ROLLBACK TRANSACTION");
    }

    public void Save(string entity)
    {
        Console.WriteLine($"Saving {entity}");
    }
}
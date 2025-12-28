namespace BackendMastery.Persistence.Transactions.SingleOperation.Infrastructure;

/// <summary>
/// Simulates a database with implicit transaction behavior.
/// </summary>
/// <remarks>
/// INTUITION:
/// - ORMs automatically wrap SaveChanges() in a transaction
/// - Developers rarely realize this
///
/// USE CASE:
/// - Single INSERT
/// - Single UPDATE
///
/// KEY RULE:
/// ❗ Failure during write must result in rollback
/// </remarks>
public class FakeDatabase
{
    public void Save(object entity)
    {
        BeginTransaction();

        try
        {
            // Simulate write
            Console.WriteLine("Writing entity to database...");

            // Uncomment to simulate failure
            // throw new Exception("Database failure");

            CommitTransaction();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
    }

    private void BeginTransaction()
    {
        Console.WriteLine("BEGIN TRANSACTION (implicit)");
    }

    private void CommitTransaction()
    {
        Console.WriteLine("COMMIT TRANSACTION");
    }

    private void RollbackTransaction()
    {
        Console.WriteLine("ROLLBACK TRANSACTION");
    }
}
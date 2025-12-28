namespace BackendMastery.Persistence.Transactions.ConsistencyRules.Infrastructure;

/// <summary>
/// Simulates a database.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Database enforces structure
/// - Not business meaning
///
/// KEY RULE:
/// ❗ Database will happily persist invalid business state
/// </remarks>
public class FakeDatabase
{
    public void BeginTransaction()
        => Console.WriteLine("BEGIN TRANSACTION");

    public void Commit()
        => Console.WriteLine("COMMIT TRANSACTION");

    public void Rollback()
        => Console.WriteLine("ROLLBACK TRANSACTION");

    public void Save(string entity)
        => Console.WriteLine($"Saving {entity}");
}
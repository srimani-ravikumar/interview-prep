namespace BackendMastery.Persistence.Transactions.AntiPatterns.Infrastructure;

public class FakeDatabase
{
    public void Save(string entity)
    {
        Console.WriteLine($"Saving {entity}");
    }
}
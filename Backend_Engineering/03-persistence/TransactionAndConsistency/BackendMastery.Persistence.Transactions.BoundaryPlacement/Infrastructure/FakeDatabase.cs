namespace BackendMastery.Persistence.Transactions.BoundaryPlacement.Infrastructure;

public class FakeDatabase
{
    public void Save(string entity)
    {
        Console.WriteLine($"Saving {entity}");
    }
}
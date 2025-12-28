namespace BackendMastery.Persistence.ORM.AntiPatterns.GoodExamples;

/// <summary>
/// Clean domain entity.
/// </summary>
/// <remarks>
/// KEY RULE:
/// ❗ Domain has no idea how persistence works
/// </remarks>
public class Order
{
    public int Id { get; }
    public string Status { get; private set; }

    public Order(int id)
    {
        Id = id;
        Status = "Pending";
    }

    public void MarkAsPaid()
    {
        Status = "Paid";
    }
}
namespace BackendMastery.Persistence.ORM.RepositoryImplementation.Domain;

/// <summary>
/// Represents an order aggregate.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Domain models business behavior
/// - It must not care how data is stored
///
/// USE CASE:
/// - Order processing lifecycle
///
/// KEY RULE:
/// ❗ Domain must be persistence-ignorant
/// </remarks>
public class Order
{
    public int Id { get; }
    public string Status { get; private set; }
    public decimal Amount { get; }

    public Order(int id, decimal amount)
    {
        Id = id;
        Amount = amount;
        Status = "Pending";
    }

    public void MarkAsPaid()
    {
        Status = "Paid";
    }
}
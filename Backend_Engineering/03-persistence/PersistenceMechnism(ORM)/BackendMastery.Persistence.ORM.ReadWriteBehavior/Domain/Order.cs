namespace BackendMastery.Persistence.ORM.ReadWriteBehavior.Domain;

/// <summary>
/// Represents an order in the system.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Domain entity is just data + behavior
/// - It does not know how it was loaded
///
/// USE CASE:
/// - Orders can be queried for reports (read-only)
/// - Orders can be modified during processing
///
/// KEY RULE:
/// ❗ Tracking is a persistence concern, not a domain concern
/// </remarks>
public class Order
{
    public int Id { get; }
    public string Status { get; private set; }
    public decimal Amount { get; }

    public Order(int id, string status, decimal amount)
    {
        Id = id;
        Status = status;
        Amount = amount;
    }

    public void MarkAsShipped()
    {
        Status = "Shipped";
    }
}
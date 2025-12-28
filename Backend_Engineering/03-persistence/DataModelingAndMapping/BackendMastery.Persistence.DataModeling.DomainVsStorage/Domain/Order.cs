namespace BackendMastery.Persistence.DataModeling.DomainVsStorage.Domain;

/// <summary>
/// Domain model representing an Order in business terms.
/// </summary>
/// <remarks>
/// INTUITION:
/// - This model answers: "What is an Order to the business?"
/// - It contains business meaning and rules
/// - It does NOT care how data is stored
///
/// KEY RULE:
/// - Domain models represent truth, not storage
/// </remarks>
public class Order
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public bool IsPriority { get; }

    public Order(Guid id, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Order amount must be positive.");

        Id = id;
        Amount = amount;

        // Business rule:
        // Priority is derived, not stored
        IsPriority = amount > 1_000;
    }
}
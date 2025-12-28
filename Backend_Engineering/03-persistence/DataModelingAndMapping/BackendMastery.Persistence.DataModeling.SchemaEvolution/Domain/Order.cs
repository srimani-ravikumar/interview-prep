namespace BackendMastery.Persistence.DataModeling.SchemaEvolution.Domain;

/// <summary>
/// Latest domain model.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Domain evolves independently
/// - Handles missing data gracefully
/// </remarks>
public class Order
{
    public OrderId Id { get; }
    public decimal Amount { get; }
    public Discount? Discount { get; }

    public decimal FinalAmount =>
        Discount is null ? Amount : Amount - Discount.Value.Amount;

    public Order(OrderId id, decimal amount, Discount? discount)
    {
        Id = id;
        Amount = amount;
        Discount = discount;
    }
}
namespace BackendMastery.Persistence.DataModeling.EntityIdentity.Storage;

/// <summary>
/// Storage representation of Order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Storage does not care about identity semantics
/// - Identity is just a column here
/// </remarks>
public class OrderRecord
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
}
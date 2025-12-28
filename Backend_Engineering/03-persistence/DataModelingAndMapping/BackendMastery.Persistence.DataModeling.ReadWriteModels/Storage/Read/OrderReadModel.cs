namespace BackendMastery.Persistence.DataModeling.ReadWriteModels.Storage.Read;

/// <summary>
/// Read-optimized representation.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Optimized for queries
/// - No joins required
/// - No business rules
/// </remarks>
public class OrderReadModel
{
    public Guid OrderId { get; set; }
    public int ItemCount { get; set; }
    public decimal TotalAmount { get; set; }
}
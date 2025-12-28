namespace BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Storage.Denormalized;

/// <summary>
/// Denormalized read model.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Optimized for queries
/// - No joins required
/// - Derived data is duplicated intentionally
/// </remarks>
public class OrderSummaryRecord
{
    public Guid OrderId { get; set; }
    public int ItemCount { get; set; }
    public decimal TotalAmount { get; set; }
}
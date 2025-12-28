namespace BackendMastery.Persistence.DataModeling.SchemaEvolution.Storage;

/// <summary>
/// Evolved storage schema (v2).
/// </summary>
/// <remarks>
/// INTUITION:
/// - Additive change (safe)
/// - Old records may not have Discount
/// </remarks>
public class OrderRecordV2
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }

    // New optional field
    public decimal? DiscountAmount { get; set; }
}
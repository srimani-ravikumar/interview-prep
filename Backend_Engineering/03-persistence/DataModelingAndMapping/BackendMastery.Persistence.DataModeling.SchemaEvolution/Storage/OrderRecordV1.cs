namespace BackendMastery.Persistence.DataModeling.SchemaEvolution.Storage;

/// <summary>
/// Original storage schema (v1).
/// </summary>
/// <remarks>
/// INTUITION:
/// - Represents data already in production
/// - Cannot be changed or re-written easily
/// </remarks>
public class OrderRecordV1
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
}
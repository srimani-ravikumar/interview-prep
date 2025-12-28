namespace BackendMastery.Persistence.DataModeling.MappingRules.Storage;

/// <summary>
/// Storage representation for Order.
/// </summary>
public class OrderRecord
{
    public Guid Id { get; set; }

    // Flattened Money
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;

    // Reference to Address record
    public Guid AddressId { get; set; }
}
namespace BackendMastery.Persistence.DataModeling.ValueObjects.Storage;

/// <summary>
/// Persistence shape for Order.
/// </summary>
public class OrderRecord
{
    public Guid Id { get; set; }

    // Flattened value objects
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;

    public string AddressLine1 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
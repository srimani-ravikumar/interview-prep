namespace BackendMastery.Persistence.DataModeling.MappingRules.Storage;

/// <summary>
/// Storage representation for Address.
/// </summary>
public class AddressRecord
{
    public Guid Id { get; set; }
    public string Line1 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
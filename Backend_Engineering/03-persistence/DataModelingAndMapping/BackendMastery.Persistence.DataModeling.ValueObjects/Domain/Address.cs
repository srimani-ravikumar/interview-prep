namespace BackendMastery.Persistence.DataModeling.ValueObjects.Domain;

/// <summary>
/// Value Object representing a physical address.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Address has no identity
/// - It is replaced as a whole
/// - Immutable and comparable by value
/// </remarks>
public readonly struct Address
{
    public string Line1 { get; }
    public string City { get; }
    public string Country { get; }

    public Address(string line1, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(line1))
            throw new ArgumentException("Line1 is required.");

        Line1 = line1;
        City = city;
        Country = country;
    }

    public override bool Equals(object? obj)
        => obj is Address other &&
           Line1 == other.Line1 &&
           City == other.City &&
           Country == other.Country;

    public override int GetHashCode()
        => HashCode.Combine(Line1, City, Country);
}
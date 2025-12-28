namespace BackendMastery.Persistence.DataModeling.MappingRules.Domain;

public readonly struct Address
{
    public string Line1 { get; }
    public string City { get; }
    public string Country { get; }

    public Address(string line1, string city, string country)
    {
        Line1 = line1;
        City = city;
        Country = country;
    }
}
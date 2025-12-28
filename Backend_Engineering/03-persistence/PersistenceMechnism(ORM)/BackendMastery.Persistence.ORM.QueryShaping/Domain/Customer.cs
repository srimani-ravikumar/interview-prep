namespace BackendMastery.Persistence.ORM.QueryShaping.Domain;

/// <summary>
/// Represents a customer aggregate.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Domain entity is rich and heavy
/// - Suitable for business behavior
///
/// KEY RULE:
/// ❗ Domain entities are NOT optimized for reads
/// </remarks>
public class Customer
{
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string Address { get; }
    public DateTime CreatedAt { get; }

    public Customer(
        int id,
        string name,
        string email,
        string address,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Email = email;
        Address = address;
        CreatedAt = createdAt;
    }
}
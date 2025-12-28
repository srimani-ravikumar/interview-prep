namespace BackendMastery.Persistence.ORM.ChangeTracking.Domain;

/// <summary>
/// Represents a domain entity.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Entity has no idea it is being tracked
/// - No persistence logic here
///
/// USE CASE:
/// - Product loaded and modified in memory
///
/// KEY RULE:
/// ❗ Domain objects must remain persistence-ignorant
/// </remarks>
public class Product
{
    public int Id { get; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public void Rename(string name)
    {
        Name = name;
    }

    public void ChangePrice(decimal price)
    {
        Price = price;
    }
}
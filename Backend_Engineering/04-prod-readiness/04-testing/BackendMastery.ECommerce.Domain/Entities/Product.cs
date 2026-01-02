using BackendMastery.ECommerce.Domain.ValueObjects;

namespace BackendMastery.ECommerce.Domain.Entities;

public class Product
{
    // Backing fields (EF Core friendly)
    private Guid _id;
    private string _name = null!;
    private Money _price = null!;

    // EF Core ONLY
    private Product() { }

    // Domain constructor
    public Product(Guid id, string name, Money price)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product Id cannot be empty");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required");

        _id = id;
        _name = name;
        _price = price ?? throw new ArgumentNullException(nameof(price));
    }

    public Guid Id => _id;
    public string Name => _name;
    public Money Price => _price;
}
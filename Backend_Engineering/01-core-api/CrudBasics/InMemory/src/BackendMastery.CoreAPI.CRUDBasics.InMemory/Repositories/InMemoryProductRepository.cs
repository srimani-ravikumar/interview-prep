using BackendMastery.CoreAPI.CRUDBasics.InMemory.Models;

namespace BackendMastery.CoreAPI.CRUDBasics.InMemory.Repositories;

/// <summary>
/// In-memory implementation
/// Used for learning, testing, and fast prototyping
/// </summary>
public class InMemoryProductRepository : IProductRepository
{
    // Runtime Constant: Static list mimics a database table
    private static readonly List<Product> _products = new();

    // Lambda Expression for better readability
    public IEnumerable<Product> GetAll() => _products;

    // Lambda Expression for better readability
    public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Update(Product product)
    {
        var existing = GetById(product.Id);

        // Exit early: Utilizing the "Pattern Matching" mechanism for null check
        if (existing is null) return;

        existing.Name = product.Name;
        existing.Price = product.Price;
    }

    public void Delete(Guid id)
    {
        var product = GetById(id);

        // Exit early: Utilizing the "Pattern Matching" mechanism for null check
        if (product is null) return;

        _products.Remove(product);
    }
}
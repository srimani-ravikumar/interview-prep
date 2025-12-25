using BackendMastery.CoreAPI.CRUDBasics.InMemory.Models;
using BackendMastery.CoreAPI.CRUDBasics.InMemory.Repositories;

namespace BackendMastery.CoreAPI.CRUDBasics.InMemory.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    // Design Pattern: Constructor Dependency Injection (In-Built Support by .NET)
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    // Lambda expression for shorthand version
    public IEnumerable<Product> GetAll() => _repository.GetAll();

    public Product? GetById(Guid id)
    {
        var product = _repository.GetById(id);

        // Exit early: Utilizing the "Pattern Matching" mechanism for null check
        if (product is null) return null;

        return product;
    }

    public Product Create(string name, decimal price)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            CreatedAt = DateTime.UtcNow
        };

        _repository.Add(product);

        return product;
    }

    public bool Update(Guid id, string name, decimal price)
    {
        // Use explicit type mentioning when RHS doesn't talks about the type to the reader
        Product? product = _repository.GetById(id);

        // Exit early: Utilizing the "Pattern Matching" mechanism for null check
        if (product is null) return false;

        product.Name = name;
        product.Price = price;

        _repository.Update(product);

        return true;
    }

    public bool Delete(Guid id)
    {
        // Use explicit type mentioning when RHS doesn't talks about the type to the reader
        Product? product = _repository.GetById(id);

        // Exit early: Utilizing the "Pattern Matching" mechanism for null check
        if (product is null) return false;

        _repository.Delete(id);

        return true;
    }
}
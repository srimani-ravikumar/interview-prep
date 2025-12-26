using BackendMastery.CoreAPI.CRUDBasics.Database.Models;
using BackendMastery.CoreAPI.CRUDBasics.Database.Repositories;

namespace BackendMastery.CoreAPI.CRUDBasics.Database.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAll() => _repository.GetAll();

    public Product? GetById(Guid id) => _repository.GetById(id);

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
        _repository.SaveChanges();

        return product;
    }

    public bool Update(Guid id, string name, decimal price)
    {
        var product = _repository.GetById(id);
        if (product is null) return false;

        product.Name = name;
        product.Price = price;

        _repository.Update(product);
        _repository.SaveChanges();

        return true;
    }

    public bool Delete(Guid id)
    {
        var product = _repository.GetById(id);
        if (product is null) return false;

        _repository.Delete(product);
        _repository.SaveChanges();

        return true;
    }
}
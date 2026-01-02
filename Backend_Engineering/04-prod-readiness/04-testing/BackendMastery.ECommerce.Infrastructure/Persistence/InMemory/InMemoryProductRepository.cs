using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Domain.Entities;
using BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;

namespace BackendMastery.ECommerce.Infrastructure.Persistence.InMemory;

/// <summary>
/// In-memory implementation of product repository.
/// Used for tests and local development.
/// </summary>
public class InMemoryProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _store = new();

    public Task AddAsync(Product product)
    {
        _store[product.Id] = product;
        return Task.CompletedTask;
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        _store.TryGetValue(id, out var product);
        return Task.FromResult(product);
    }
}
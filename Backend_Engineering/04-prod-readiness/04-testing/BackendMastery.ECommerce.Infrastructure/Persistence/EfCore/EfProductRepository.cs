using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Domain.Entities;

namespace BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;

/// <summary>
/// EF Core implementation of product repository.
/// </summary>
public class EfProductRepository : IProductRepository
{
    private readonly ECommerceDbContext _dbContext;

    public EfProductRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return _dbContext.Products.FindAsync(id).AsTask();
    }
}
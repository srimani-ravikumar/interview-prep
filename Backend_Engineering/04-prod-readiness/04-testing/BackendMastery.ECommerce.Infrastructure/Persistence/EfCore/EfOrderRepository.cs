using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Domain.Entities;

namespace BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;

/// <summary>
/// EF Core implementation of order repository.
/// </summary>
public class EfOrderRepository : IOrderRepository
{
    private readonly ECommerceDbContext _dbContext;

    public EfOrderRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        return _dbContext.Orders.FindAsync(id).AsTask();
    }
}
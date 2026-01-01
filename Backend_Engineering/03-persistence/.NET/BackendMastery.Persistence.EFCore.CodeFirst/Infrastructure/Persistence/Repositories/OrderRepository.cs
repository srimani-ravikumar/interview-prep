using BackendMastery.Persistence.EFCore.CodeFirst.Application.Abstractions;
using BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Infrastructure.Persistence.Repositories;

/// <summary>
/// EF Core backed repository.
/// </summary>
/// <remarks>
/// INTUITION:
/// - EF Core handles tracking & change detection
/// - Repository controls access boundaries
///
/// KEY RULE:
/// ❗ No business logic here
/// </remarks>
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public OrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Order order)
    {
        await _db.Orders.AddAsync(order);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}
using BackendMastery.StandardAPI.Application.Interfaces.Repositories;
using BackendMastery.StandardAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendMastery.StandardAPI.Infrastructure.Persistence.Repositories;

/// <summary>
/// EF Core implementation of Order repository.
/// </summary>
/// <remarks>
/// Intuition:
/// - Implements persistence contract
/// - Translates domain operations to EF Core
///
/// This class:
/// - Depends on EF Core
/// - Implements Application-layer interface
/// </remarks>
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IReadOnlyList<Order>> GetAllAsync()
    {
        return await _context.Orders
            .AsNoTracking()
            .ToListAsync();
    }
}
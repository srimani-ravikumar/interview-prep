using BackendMastery.Persistence.EFCore.CodeFirst.Application.Abstractions;
using BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;
using BackendMastery.Persistence.EFCore.CodeFirst.Domain.ValueObjects;
using BackendMastery.Persistence.EFCore.CodeFirst.Infrastructure.Persistence;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Application.Services;

/// <summary>
/// Application service orchestrating use cases.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Coordinates domain + persistence
/// - Controls transaction boundary
///
/// KEY RULE:
/// ❗ SaveChanges belongs to the application boundary
/// </remarks>
public class OrderService
{
    private readonly IOrderRepository _repo;
    private readonly AppDbContext _db;

    public OrderService(
        IOrderRepository repo,
        AppDbContext db)
    {
        _repo = repo;
        _db = db;
    }

    public async Task<Guid> CreateOrderAsync(decimal amount)
    {
        var order = new Order(new Money(amount, "INR"));
        order.AddItem("Sample Item", 1);

        await _repo.AddAsync(order);
        await _db.SaveChangesAsync(); // Unit of Work

        return order.Id;
    }
}
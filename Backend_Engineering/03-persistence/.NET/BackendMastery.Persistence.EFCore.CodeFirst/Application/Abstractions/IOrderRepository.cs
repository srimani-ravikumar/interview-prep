using BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Application.Abstractions;

/// <summary>
/// Repository abstraction for Order aggregate.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Application should not depend on EF Core
/// - Only expose aggregate-safe operations
///
/// KEY RULE:
/// ❗ Repositories operate on aggregates, not tables
/// </remarks>
public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
}
using BackendMastery.StandardAPI.Domain.Models;

namespace BackendMastery.StandardAPI.Application.Interfaces.Repositories;

/// <summary>
/// Repository contract for Order persistence.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Defines WHAT data the application needs
/// - Hides HOW data is stored
/// </para>
/// <para>
/// This interface:
/// - Belongs to the Application layer
/// - Depends on Domain models
/// </para>
/// <para>
/// It knows NOTHING about:
/// - EF Core (ORM)
/// - SQL (Direct Connection via SQL Adapter)
/// - Infrastructure
/// </para>
/// </remarks>
public interface IOrderRepository
{
    /// <summary>
    /// Persists a new order.
    /// </summary>
    /// <remarks>
    /// Use case:
    /// - Called when a new order is placed
    /// </remarks>
    Task AddAsync(Order order);

    /// <summary>
    /// Retrieves an order by its identifier.
    /// </summary>
    Task<Order?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    Task<IReadOnlyList<Order>> GetAllAsync();
}
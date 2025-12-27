using BackendMastery.Architecture.StandardAPI.Domain.Models;

namespace BackendMastery.Architecture.StandardAPI.Application.Interfaces.Services;

/// <summary>
/// Use-case contract for Order operations.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Represents WHAT the application can do with Orders
/// - Hides workflow and orchestration details
/// </para>
/// <para>
/// This interface:
/// - Belongs to the Application layer
/// - Depends only on Domain models
/// </para>
/// </remarks>
public interface IOrderService
{
    Task<Order> PlaceOrderAsync(decimal amount);

    Task<Order?> GetOrderByIdAsync(Guid id);

    Task<IReadOnlyList<Order>> GetAllOrdersAsync();
}
using BackendMastery.Architecture.DependencyInjection.Models;

namespace BackendMastery.Architecture.DependencyInjection.Services.Interfaces;

/// <summary>
/// Service abstraction.
/// </summary>
/// <remarks>
/// Intuition:
/// - Exposes business operations
/// - Hides implementation details
/// </remarks>
public interface IOrderService
{
    void CreateOrder(string product);
    IEnumerable<Order> GetOrders();
}
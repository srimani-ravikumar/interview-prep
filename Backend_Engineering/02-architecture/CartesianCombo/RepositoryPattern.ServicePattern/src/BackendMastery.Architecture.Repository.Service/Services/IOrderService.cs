using BackendMastery.Architecture.Repository.Service.Models;

namespace BackendMastery.Architecture.Repository.Service.Services;

/// <summary>
/// Use-case contract for order operations.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents WHAT the system does with orders
/// - Hides workflow and rules
///
/// This is a behavior boundary.
/// </remarks>
public interface IOrderService
{
    Order PlaceOrder(decimal amount);
}
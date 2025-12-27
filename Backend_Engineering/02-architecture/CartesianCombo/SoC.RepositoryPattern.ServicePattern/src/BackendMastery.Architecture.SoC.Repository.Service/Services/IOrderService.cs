using BackendMastery.Architecture.SoC.Repository.Service.Models;

namespace BackendMastery.Architecture.SoC.Repository.Service.Services;

/// <summary>
/// Use-case contract for order operations.
/// </summary>
/// <remarks>
/// Intuition:
/// - Defines WHAT the system does
/// - Hides business workflow
/// </remarks>
public interface IOrderService
{
    Order PlaceOrder(decimal amount);
}
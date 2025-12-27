using BackendMastery.Architecture.Service.Models;

namespace BackendMastery.Architecture.Service.Services;

/// <summary>
/// Applies discount rules.
/// </summary>
/// <remarks>
/// Intuition:
/// - Encapsulates discount logic
/// - Changes when discount policy changes
///
/// This is a service because:
/// - It represents business behavior
/// - It is reusable
/// </remarks>
public class DiscountService
{
    public decimal CalculateDiscount(Order order)
    {
        return order.IsPremiumCustomer
            ? order.BaseAmount * 0.10m
            : 0m;
    }
}
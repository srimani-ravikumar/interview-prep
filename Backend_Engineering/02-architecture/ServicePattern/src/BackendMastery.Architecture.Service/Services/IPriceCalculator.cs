using BackendMastery.Architecture.Service.Models;

namespace BackendMastery.Architecture.Service.Services;

/// <summary>
/// Use-case contract for price calculation.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents WHAT the system can do
/// - Hides HOW pricing is calculated
///
/// Use case:
/// - Allows multiple entry points (API, CLI, batch)
/// - Enables easy testing and substitution
///
/// Important:
/// - This is NOT about DI frameworks
/// - This is about defining a stable behavior boundary
/// </remarks>
public interface IPriceCalculator
{
    PriceBreakdown CalculatePrice(Order order);
}
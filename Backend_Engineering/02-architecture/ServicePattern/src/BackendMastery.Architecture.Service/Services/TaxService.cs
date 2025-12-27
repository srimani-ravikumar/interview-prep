using BackendMastery.Architecture.Service.Models;

namespace BackendMastery.Architecture.Service.Services;

/// <summary>
/// Applies tax rules.
/// </summary>
/// <remarks>
/// Intuition:
/// - Encapsulates tax computation
/// - Changes when tax regulations change
/// </remarks>
public class TaxService
{
    public decimal CalculateTax(decimal amountAfterDiscount)
    {
        return amountAfterDiscount * 0.18m;
    }
}
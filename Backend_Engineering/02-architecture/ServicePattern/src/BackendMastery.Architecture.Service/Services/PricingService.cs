using BackendMastery.Architecture.Service.Models;

namespace BackendMastery.Architecture.Service.Services;

/// <summary>
/// Concrete implementation of pricing behavior.
/// </summary>
/// <remarks>
/// Intuition:
/// - Orchestrates discount + tax rules
/// - Owns the pricing workflow
///
/// This class:
/// - Implements the use case
/// - Does NOT store data
/// - Does NOT handle I/O
/// </remarks>
public class PricingService : IPriceCalculator
{
    private readonly DiscountService _discountService;
    private readonly TaxService _taxService;

    public PricingService(
        DiscountService discountService,
        TaxService taxService)
    {
        _discountService = discountService;
        _taxService = taxService;
    }

    public PriceBreakdown CalculatePrice(Order order)
    {
        var discount = _discountService.CalculateDiscount(order);
        var amountAfterDiscount = order.BaseAmount - discount;
        var tax = _taxService.CalculateTax(amountAfterDiscount);

        return new PriceBreakdown
        {
            BaseAmount = order.BaseAmount,
            Discount = discount,
            Tax = tax,
            FinalPrice = amountAfterDiscount + tax
        };
    }
}
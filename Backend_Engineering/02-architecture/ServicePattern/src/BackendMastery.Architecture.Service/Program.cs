using BackendMastery.Architecture.Service.Models;
using BackendMastery.Architecture.Service.Services;

/// <summary>
/// Application entry point.
/// </summary>
/// <remarks>
/// Intuition:
/// - Demonstrates service usage
/// - No HTTP, no MVC
/// - Service usable from anywhere/// 
/// </remarks>
/// 
var discountService = new DiscountService();
var taxService = new TaxService();

// Using Liskov Substituion Princple of SOLID & Utilizing named arguments to enhance clarity
IPriceCalculator pricingService = 
    new PricingService(
        discountService: discountService, 
        taxService: taxService
    );

var order = new Order
{
    BaseAmount = 1000m,
    IsPremiumCustomer = true
};

// Explicitly mentioning the type when RHS doesn't talk about the type to the reader
PriceBreakdown result = pricingService.CalculatePrice(order);

Console.WriteLine($"Final Price: {result.FinalPrice}");
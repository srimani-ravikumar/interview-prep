namespace BackendMastery.Architecture.Service.Models;

/// <summary>
/// Output model representing pricing result.
/// </summary>
/// <remarks>
/// Intuition:
/// - Communicates outcome of business rules
/// - Keeps calculation steps transparent
/// </remarks>
public class PriceBreakdown
{
    public decimal BaseAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal FinalPrice { get; set; }
}
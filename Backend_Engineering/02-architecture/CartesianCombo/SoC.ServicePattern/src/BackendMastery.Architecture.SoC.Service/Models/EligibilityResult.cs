namespace BackendMastery.Architecture.SoC.Service.Models;

/// <summary>
/// Output model of eligibility decision.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents the outcome of business rules
/// - Keeps decision explicit
/// </remarks>
public class EligibilityResult
{
    public bool IsApproved { get; set; }
    public string Reason { get; set; } = string.Empty;
}
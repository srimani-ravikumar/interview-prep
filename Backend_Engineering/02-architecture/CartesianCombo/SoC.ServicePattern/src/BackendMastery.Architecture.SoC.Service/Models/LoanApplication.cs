namespace BackendMastery.Architecture.SoC.Service.Models;

/// <summary>
/// Input model representing a loan application.
/// </summary>
/// <remarks>
/// Intuition:
/// - Carries user-provided data
/// - No behavior inside
///
/// Reason to change:
/// - Input contract changes
/// </remarks>
public class LoanApplication
{
    public int CreditScore { get; set; }
    public decimal MonthlyIncome { get; set; }
}
using BackendMastery.Architecture.SoC.Service.Models;

namespace BackendMastery.Architecture.SoC.Service.Validation;

/// <summary>
/// Validates loan application inputs.
/// </summary>
/// <remarks>
/// Intuition:
/// - Fail fast for invalid inputs
/// - Prevents rules from handling bad data
///
/// Reason to change:
/// - Validation constraints evolve
/// </remarks>
public class ApplicationValidator
{
    public bool IsValid(LoanApplication application)
    {
        return application.CreditScore > 0
            && application.MonthlyIncome > 0;
    }
}
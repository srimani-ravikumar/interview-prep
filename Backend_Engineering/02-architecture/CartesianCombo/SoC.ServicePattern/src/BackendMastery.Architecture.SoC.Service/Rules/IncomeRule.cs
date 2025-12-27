using BackendMastery.Architecture.SoC.Service.Models;

namespace BackendMastery.Architecture.SoC.Service.Rules;

/// <summary>
/// Evaluates income rule.
/// </summary>
/// <remarks>
/// Intuition:
/// - Independent eligibility rule
///
/// Reason to change:
/// - Income threshold changes
/// </remarks>
public class IncomeRule
{
    public bool IsSatisfied(LoanApplication application)
    {
        return application.MonthlyIncome >= 30000;
    }
}
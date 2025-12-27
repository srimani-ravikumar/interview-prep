using BackendMastery.Architecture.SoC.Service.Models;

namespace BackendMastery.Architecture.SoC.Service.Rules;

/// <summary>
/// Evaluates credit score rule.
/// </summary>
/// <remarks>
/// Intuition:
/// - Isolated business rule
/// - Changes independently
///
/// Reason to change:
/// - Risk policy updates
/// </remarks>
public class CreditScoreRule
{
    public bool IsSatisfied(LoanApplication application)
    {
        return application.CreditScore >= 700;
    }
}
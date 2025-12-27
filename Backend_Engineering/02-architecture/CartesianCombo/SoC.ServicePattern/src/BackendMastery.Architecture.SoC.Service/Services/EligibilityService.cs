using BackendMastery.Architecture.SoC.Service.Models;
using BackendMastery.Architecture.SoC.Service.Rules;

namespace BackendMastery.Architecture.SoC.Service.Services;

/// <summary>
/// Orchestrates eligibility decision workflow.
/// </summary>
/// <remarks>
/// Intuition:
/// - Coordinates multiple rules
/// - Owns the decision process
///
/// This is the Service Pattern:
/// - Stateless
/// - Behavior-focused
/// - No persistence
/// </remarks>
public class EligibilityService : IEligibilityEvaluator
{
    private readonly CreditScoreRule _creditScoreRule;
    private readonly IncomeRule _incomeRule;

    public EligibilityService(
        CreditScoreRule creditScoreRule,
        IncomeRule incomeRule)
    {
        _creditScoreRule = creditScoreRule;
        _incomeRule = incomeRule;
    }

    public EligibilityResult Evaluate(LoanApplication application)
    {
        if (!_creditScoreRule.IsSatisfied(application))
        {
            return new EligibilityResult
            {
                IsApproved = false,
                Reason = "Credit score too low"
            };
        }

        if (!_incomeRule.IsSatisfied(application))
        {
            return new EligibilityResult
            {
                IsApproved = false,
                Reason = "Insufficient income"
            };
        }

        return new EligibilityResult
        {
            IsApproved = true,
            Reason = "Approved"
        };
    }
}
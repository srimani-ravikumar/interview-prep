using BackendMastery.Architecture.SoC.Service.Models;

namespace BackendMastery.Architecture.SoC.Service.Services;

/// <summary>
/// Use-case contract for eligibility evaluation.
/// </summary>
/// <remarks>
/// Intuition:
/// - Represents WHAT the system decides
/// - Hides HOW rules are applied
///
/// This is the behavior boundary.
/// </remarks>
public interface IEligibilityEvaluator
{
    EligibilityResult Evaluate(LoanApplication application);
}
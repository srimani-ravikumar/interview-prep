using BackendMastery.Architecture.SoC.Service.Models;
using BackendMastery.Architecture.SoC.Service.Rules;
using BackendMastery.Architecture.SoC.Service.Services;
using BackendMastery.Architecture.SoC.Service.Validation;

/// <summary>
/// Application entry point.
/// </summary>
/// <remarks>
/// Intuition:
/// - Wires services and rules
/// - No framework assumptions
/// </remarks>
var validator = new ApplicationValidator();
var creditScoreRule = new CreditScoreRule();
var incomeRule = new IncomeRule();

IEligibilityEvaluator evaluator = new EligibilityService(creditScoreRule, incomeRule);

var application = new LoanApplication
{
    CreditScore = 720,
    MonthlyIncome = 45000
};

// Fail Fast
if (!validator.IsValid(application))
{
    Console.WriteLine("Invalid application");
    return;
}

var result = evaluator.Evaluate(application);
Console.WriteLine(result.Reason);
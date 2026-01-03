using BackendMastery.ProdReadiness.SafeDeployments.Contracts;
using BackendMastery.ProdReadiness.SafeDeployments.Infrastructure;

namespace BackendMastery.ProdReadiness.SafeDeployments.Services;

/// <summary>
/// WHY:
/// Centralizes version-aware business decisions.
///
/// WHAT PROBLEM IT SOLVES:
/// Keeps controllers thin and rollback-friendly.
///
/// WHAT BREAKS IF MISUSED:
/// Returning anonymous types hides contract evolution.
/// </summary>
public sealed class OrderService
{
    private readonly FeatureFlagProvider _flags;

    public OrderService(FeatureFlagProvider flags)
    {
        _flags = flags;
    }

    public object GetOrder()
    {
        if (_flags.IsOrderV2Enabled())
        {
            return new OrderResponseV2
            {
                Id = Guid.NewGuid(),
                Amount = 100,
                Currency = "INR",
                DiscountApplied = true
            };
        }

        return new OrderResponseV1
        {
            Id = Guid.NewGuid(),
            Amount = 100
        };
    }
}
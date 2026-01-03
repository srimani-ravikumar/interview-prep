using BackendMastery.ProdReadiness.SafeDeployments.Configuration;
using Microsoft.Extensions.Options;

namespace BackendMastery.ProdReadiness.SafeDeployments.Infrastructure;

/// <summary>
/// WHY:
/// Centralizes feature-flag decisions.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents feature flags from spreading across code.
///
/// WHAT BREAKS IF MISUSED:
/// Inline flags become permanent tech debt.
/// </summary>
public sealed class FeatureFlagProvider
{
    private readonly DeploymentOptions _options;

    public FeatureFlagProvider(IOptions<DeploymentOptions> options)
    {
        _options = options.Value;
    }

    public bool IsOrderV2Enabled() => _options.EnableOrderV2;
}
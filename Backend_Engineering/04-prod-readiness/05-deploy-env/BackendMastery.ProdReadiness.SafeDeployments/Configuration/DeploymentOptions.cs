namespace BackendMastery.ProdReadiness.SafeDeployments.Configuration;

/// <summary>
/// WHY:
/// Controls release behavior without redeployment.
///
/// WHAT PROBLEM IT SOLVES:
/// Allows instant rollback via configuration.
///
/// WHAT BREAKS IF MISUSED:
/// Hard-coded behavior makes rollback impossible.
/// </summary>
public sealed class DeploymentOptions
{
    public bool EnableOrderV2 { get; init; }
}
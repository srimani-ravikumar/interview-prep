namespace BackendMastery.ProdReadiness.SecretsManagement.Contracts;

/// <summary>
/// WHY:
/// Ensures no sensitive material is ever serialized.
///
/// WHAT BREAKS IF MISUSED:
/// Exposing internal objects leaks secrets.
/// </summary>
public sealed class SecurePingResponse
{
    public string Status { get; init; } = string.Empty;
}
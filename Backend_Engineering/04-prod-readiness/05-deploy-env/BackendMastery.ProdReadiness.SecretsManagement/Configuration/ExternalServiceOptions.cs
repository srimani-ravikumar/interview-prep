namespace BackendMastery.ProdReadiness.SecretsManagement.Configuration;

/// <summary>
/// WHY:
/// Holds non-sensitive configuration required to call an external service.
///
/// WHAT PROBLEM IT SOLVES:
/// Separates safe configuration from credentials.
///
/// WHAT BREAKS IF MISUSED:
/// Mixing secrets here leads to accidental exposure.
/// </summary>
public sealed class ExternalServiceOptions
{
    public string BaseUrl { get; init; } = string.Empty;
    public int TimeoutSeconds { get; init; }
}
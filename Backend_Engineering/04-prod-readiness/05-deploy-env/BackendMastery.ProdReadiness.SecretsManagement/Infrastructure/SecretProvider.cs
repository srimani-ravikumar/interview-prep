namespace BackendMastery.ProdReadiness.SecretsManagement.Infrastructure;

/// <summary>
/// WHY:
/// Centralizes secret access behind a single boundary.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents secrets from spreading across the codebase.
///
/// WHEN TO USE:
/// Any credential, token, or signing material.
///
/// WHAT BREAKS IF MISUSED:
/// Inline secret access makes rotation and auditing impossible.
/// </summary>
public sealed class SecretProvider
{
    public string GetExternalServiceApiKey()
    {
        var secret = Environment.GetEnvironmentVariable("EXTERNAL_SERVICE_API_KEY");

        if (string.IsNullOrWhiteSpace(secret))
            throw new InvalidOperationException("Required secret is missing.");

        return secret;
    }
}
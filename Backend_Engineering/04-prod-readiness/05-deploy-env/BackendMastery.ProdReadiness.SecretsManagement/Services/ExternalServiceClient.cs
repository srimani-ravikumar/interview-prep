using BackendMastery.ProdReadiness.SecretsManagement.Configuration;
using BackendMastery.ProdReadiness.SecretsManagement.Infrastructure;
using Microsoft.Extensions.Options;

namespace BackendMastery.ProdReadiness.SecretsManagement.Services;

/// <summary>
/// WHY:
/// Demonstrates safe consumption of secrets without persisting them.
///
/// WHAT PROBLEM IT SOLVES:
/// Prevents secrets from being logged or stored.
///
/// WHAT BREAKS IF MISUSED:
/// Caching secrets increases leak surface.
/// </summary>
public sealed class ExternalServiceClient
{
    private readonly ExternalServiceOptions _options;
    private readonly SecretProvider _secretProvider;

    public ExternalServiceClient(
        IOptions<ExternalServiceOptions> options,
        SecretProvider secretProvider)
    {
        _options = options.Value;
        _secretProvider = secretProvider;
    }

    public string Ping()
    {
        var apiKey = _secretProvider.GetExternalServiceApiKey();

        // Simulated external call using secret
        return $"Pinged {_options.BaseUrl} with secure credentials.";
    }
}
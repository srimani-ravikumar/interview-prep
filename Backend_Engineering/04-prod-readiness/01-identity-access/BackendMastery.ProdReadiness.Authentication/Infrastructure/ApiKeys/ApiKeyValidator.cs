namespace BackendMastery.ProdReadiness.Authentication.Infrastructure.ApiKeys;

/// WHY: Enables API Key based authentication.
/// USE CASE: Internal tools, partners, low-complexity integrations.
/// WARNING: API keys must be rotated and scoped carefully.
public sealed class ApiKeyValidator
{
    private readonly HashSet<string> _validKeys;

    public ApiKeyValidator(IEnumerable<string> keys)
    {
        _validKeys = keys.Select(k => k.Trim()).ToHashSet();
    }

    public bool IsValid(string providedKey)
        => _validKeys.Contains(providedKey);
}
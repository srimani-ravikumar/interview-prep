namespace BackendMastery.ProdReadiness.Authentication.Services;

/// WHY: Verifies username/password credentials.
/// USE CASE: First authentication step for human users.
/// WARNING: Real systems must hash + salt passwords.
public sealed class CredentialAuthenticationService
{
    private static readonly Dictionary<string, string> _users =
        new()
        {
            ["alice"] = "password123",
            ["bob"] = "password456"
        };

    public bool Validate(string username, string password)
    {
        return _users.TryGetValue(username, out var stored)
               && stored == password;
    }
}
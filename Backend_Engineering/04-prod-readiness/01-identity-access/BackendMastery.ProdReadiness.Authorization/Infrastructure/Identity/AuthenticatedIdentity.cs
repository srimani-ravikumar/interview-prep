namespace BackendMastery.ProdReadiness.Authorization.Infrastructure.Identity;

/// WHY: Represents a verified identity entering the authorization layer.
/// USE CASE: Authorization logic consumes identity attributes.
/// WARNING: Authorization assumes identity is already trustworthy.
public sealed class AuthenticatedIdentity
{
    public string Subject { get; }
    public IReadOnlyDictionary<string, string> Claims { get; }

    public AuthenticatedIdentity(
        string subject,
        IReadOnlyDictionary<string, string> claims)
    {
        Subject = subject;
        Claims = claims;
    }
}
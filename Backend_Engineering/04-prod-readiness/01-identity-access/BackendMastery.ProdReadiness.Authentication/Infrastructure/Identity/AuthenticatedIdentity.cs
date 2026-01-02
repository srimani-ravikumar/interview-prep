namespace BackendMastery.ProdReadiness.Authentication.Infrastructure.Identity;

/// WHY: Represents a successfully authenticated caller.
/// USE CASE: Downstream code trusts this object as "identity is verified".
/// WARNING: If identity is forged or incomplete, authorization becomes meaningless.
public sealed class AuthenticatedIdentity
{
    public string Subject { get; }
    public string AuthenticationScheme { get; }
    public IReadOnlyDictionary<string, string> Claims { get; }

    public AuthenticatedIdentity(
        string subject,
        string authenticationScheme,
        IReadOnlyDictionary<string, string> claims)
    {
        Subject = subject;
        AuthenticationScheme = authenticationScheme;
        Claims = claims;
    }
}
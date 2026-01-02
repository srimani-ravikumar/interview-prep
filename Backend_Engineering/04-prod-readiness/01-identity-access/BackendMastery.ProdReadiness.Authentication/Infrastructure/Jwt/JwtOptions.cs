namespace BackendMastery.ProdReadiness.Authentication.Infrastructure.Jwt;

/// WHY: Central definition of JWT validation rules.
/// USE CASE: Ensures tokens are validated consistently.
/// WARNING: Weak validation here = full auth bypass.
public sealed class JwtOptions
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string SigningKey { get; init; } = string.Empty;
}
namespace BackendMastery.ProdReadiness.Authentication.Contracts;

/// WHY: Exposes authenticated identity for inspection.
/// USE CASE: Verifying authentication behavior.
/// WARNING: Do not expose sensitive claims in real APIs.
public sealed record IdentityResponse(
    string Subject,
    string AuthenticationScheme,
    IReadOnlyDictionary<string, string> Claims);
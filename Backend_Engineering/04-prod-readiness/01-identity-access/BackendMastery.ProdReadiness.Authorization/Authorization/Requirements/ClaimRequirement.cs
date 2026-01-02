namespace BackendMastery.ProdReadiness.Authorization.Authorization.Requirements;

/// WHY: Enables claims-based authorization.
/// USE CASE: Access depends on attributes, not roles.
/// WARNING: Claims must be trusted inputs.
public sealed class ClaimRequirement : IAuthorizationRequirement
{
    private readonly string _claim;
    private readonly string _value;

    public ClaimRequirement(string claim, string value)
    {
        _claim = claim;
        _value = value;
    }

    public AuthorizationDecision Evaluate(AuthorizationContext context)
    {
        if (context.Identity.Claims.TryGetValue(_claim, out var actual) &&
            actual == _value)
        {
            return AuthorizationDecision.Allow();
        }

        return AuthorizationDecision.Deny(
            $"Missing required claim {_claim}:{_value}");
    }
}
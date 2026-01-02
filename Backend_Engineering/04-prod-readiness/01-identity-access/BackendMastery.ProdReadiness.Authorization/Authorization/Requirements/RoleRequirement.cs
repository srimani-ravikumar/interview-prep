namespace BackendMastery.ProdReadiness.Authorization.Authorization.Requirements;

/// WHY: Enforces role-based access control.
/// USE CASE: Simple systems with stable access rules.
/// WARNING: Overuse leads to role explosion.
public sealed class RoleRequirement : IAuthorizationRequirement
{
    private readonly string _requiredRole;

    public RoleRequirement(string requiredRole)
    {
        _requiredRole = requiredRole;
    }

    public AuthorizationDecision Evaluate(AuthorizationContext context)
    {
        if (context.Identity.Claims.TryGetValue("role", out var role) &&
            role == _requiredRole)
        {
            return AuthorizationDecision.Allow();
        }

        return AuthorizationDecision.Deny(
            $"Required role '{_requiredRole}' not present");
    }
}
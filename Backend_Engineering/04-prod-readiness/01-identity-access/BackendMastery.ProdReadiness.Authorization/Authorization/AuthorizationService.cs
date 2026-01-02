namespace BackendMastery.ProdReadiness.Authorization.Authorization;

/// WHY: Centralizes authorization logic.
/// USE CASE: Prevents scattered security rules.
/// WARNING: Controllers must never bypass this.
public sealed class AuthorizationService
{
    public AuthorizationDecision Authorize(
        AuthorizationContext context,
        params IAuthorizationRequirement[] requirements)
    {
        foreach (var requirement in requirements)
        {
            var decision = requirement.Evaluate(context);

            if (!decision.IsAllowed)
                return decision;
        }

        return AuthorizationDecision.Allow();
    }
}
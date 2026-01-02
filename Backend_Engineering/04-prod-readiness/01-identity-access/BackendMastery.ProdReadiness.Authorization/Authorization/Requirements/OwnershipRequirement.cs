namespace BackendMastery.ProdReadiness.Authorization.Authorization.Requirements;

/// WHY: Enforces resource-based authorization.
/// USE CASE: Ownership checks (most common real-world rule).
/// WARNING: Most systems implement this incorrectly.
public sealed class OwnershipRequirement<TResource> : IAuthorizationRequirement
{
    private readonly Func<TResource, string> _ownerSelector;

    public OwnershipRequirement(Func<TResource, string> ownerSelector)
    {
        _ownerSelector = ownerSelector;
    }

    public AuthorizationDecision Evaluate(AuthorizationContext context)
    {
        if (context.Resource is not TResource resource)
            return AuthorizationDecision.Deny("Invalid resource");

        var ownerId = _ownerSelector(resource);

        if (context.Identity.Subject == ownerId)
            return AuthorizationDecision.Allow();

        return AuthorizationDecision.Deny("Caller does not own resource");
    }
}
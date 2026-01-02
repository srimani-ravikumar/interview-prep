using BackendMastery.ProdReadiness.Authorization.Infrastructure.Identity;

namespace BackendMastery.ProdReadiness.Authorization.Authorization;

/// WHY: Bundles everything needed to make an authorization decision.
/// USE CASE: Prevents hidden dependencies.
/// WARNING: Missing context leads to insecure shortcuts.
public sealed class AuthorizationContext
{
    public AuthenticatedIdentity Identity { get; }
    public object? Resource { get; }

    public AuthorizationContext(
        AuthenticatedIdentity identity,
        object? resource = null)
    {
        Identity = identity;
        Resource = resource;
    }
}
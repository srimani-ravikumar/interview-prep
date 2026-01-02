namespace BackendMastery.ProdReadiness.Authorization.Authorization;

/// WHY: Represents the result of an authorization evaluation.
/// USE CASE: Prevents authorization logic from leaking into controllers.
/// WARNING: Decisions must be explicit — never inferred.
public sealed class AuthorizationDecision
{
    public bool IsAllowed { get; }
    public string Reason { get; }

    private AuthorizationDecision(bool allowed, string reason)
    {
        IsAllowed = allowed;
        Reason = reason;
    }

    public static AuthorizationDecision Allow()
        => new(true, "Access granted");

    public static AuthorizationDecision Deny(string reason)
        => new(false, reason);
}
namespace BackendMastery.ProdReadiness.Authorization.Authorization;

/// WHY: Marker for an authorization rule.
/// USE CASE: Allows composable, testable authorization logic.
/// WARNING: Requirements must be business-driven, not technical.
public interface IAuthorizationRequirement
{
    AuthorizationDecision Evaluate(AuthorizationContext context);
}
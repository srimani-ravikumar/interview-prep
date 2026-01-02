namespace BackendMastery.ProdReadiness.Authorization.Contracts;

/// WHY: Represents a protected resource.
/// USE CASE: Demonstrates ownership-based authorization.
/// WARNING: Real systems fetch from DB.
public sealed record OrderResponse(
    string OrderId,
    string OwnerId,
    string Status);
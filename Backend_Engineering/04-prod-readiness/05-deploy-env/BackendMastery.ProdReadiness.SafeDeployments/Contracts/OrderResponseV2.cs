namespace BackendMastery.ProdReadiness.SafeDeployments.Contracts;

/// <summary>
/// WHY:
/// Represents an evolved API contract introduced safely.
///
/// WHAT PROBLEM IT SOLVES:
/// Allows adding new capabilities without breaking existing clients.
///
/// WHEN TO USE:
/// When rolling out enhancements behind feature flags.
///
/// WHAT BREAKS IF MISUSED:
/// Treating this as a replacement instead of an addition forces unsafe rollbacks.
/// </summary>
public sealed class OrderResponseV2
{
    public Guid Id { get; init; }

    public decimal Amount { get; init; }

    public string Currency { get; init; } = string.Empty;

    public bool DiscountApplied { get; init; }
}
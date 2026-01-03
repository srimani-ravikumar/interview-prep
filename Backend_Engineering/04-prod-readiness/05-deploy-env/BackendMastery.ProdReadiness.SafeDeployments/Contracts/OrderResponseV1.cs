namespace BackendMastery.ProdReadiness.SafeDeployments.Contracts;

/// <summary>
/// WHY:
/// Represents the original API contract already consumed by clients.
///
/// WHAT PROBLEM IT SOLVES:
/// Establishes a stable baseline that must never break.
///
/// WHEN TO USE:
/// When supporting existing clients during incremental rollouts.
///
/// WHAT BREAKS IF MISUSED:
/// Removing or renaming fields causes immediate client failures.
/// </summary>
public sealed class OrderResponseV1
{
    public Guid Id { get; init; }

    public decimal Amount { get; init; }
}
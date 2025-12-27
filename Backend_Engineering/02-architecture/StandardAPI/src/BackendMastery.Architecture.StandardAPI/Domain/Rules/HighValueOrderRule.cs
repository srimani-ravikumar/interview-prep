using BackendMastery.Architecture.StandardAPI.Domain.Exceptions;

namespace BackendMastery.Architecture.StandardAPI.Domain.Rules;

/// <summary>
/// Business rule for high-value orders.
/// </summary>
/// <remarks>
/// Intuition:
/// - Encapsulates a single business policy
/// - Keeps domain model clean
///
/// Why this exists:
/// - Business rules change frequently
/// - Isolating rules avoids fat entities
///
/// This rule knows NOTHING about:
/// - HTTP
/// - Databases
/// - EF Core
/// </remarks>
public static class HighValueOrderRule
{
    private const decimal ApprovalThreshold = 10_000m;

    public static void Enforce(decimal amount, bool isApproved)
    {
        if (amount > ApprovalThreshold && !isApproved)
        {
            throw new InvalidOrderException("High-value orders require explicit approval.");
        }
    }
}
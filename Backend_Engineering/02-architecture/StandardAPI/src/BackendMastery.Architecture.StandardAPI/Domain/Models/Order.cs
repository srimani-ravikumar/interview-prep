using BackendMastery.Architecture.StandardAPI.Domain.Exceptions;
using BackendMastery.Architecture.StandardAPI.Domain.Rules;

namespace BackendMastery.Architecture.StandardAPI.Domain.Models;

/// <summary>
/// Represents an Order in the business domain.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - This is a domain entity, not a DTO
/// - It represents persisted business state
/// </para>
/// <para>
/// Domain rules:
/// - Amount must be positive
/// - Priority is derived from business rule
/// </para>
/// <para>
/// This class knows NOTHING about:
/// - Databases
/// - HTTP
/// - EF Core
/// </para>
/// </remarks>
public class Order
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsPriority { get; private set; }
    public bool IsApproved { get; private set; }

    // Constructor enforces invariants (fail-fast)
    public Order(decimal amount, bool isApproved)
    {
        if (amount <= 0)
            throw new InvalidOrderException("Order amount must be greater than zero.");

        // Enforce business rule
        HighValueOrderRule.Enforce(amount, isApproved);

        Id = Guid.NewGuid();
        Amount = amount;
        IsPriority = amount > 1000;
    }

    // Private constructor for ORM usage (future EF Core)
    private Order() { }
}
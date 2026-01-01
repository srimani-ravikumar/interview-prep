namespace BackendMastery.Persistence.EFCore.CodeFirst.Domain.ValueObjects;

/// <summary>
/// Represents money safely.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Money is not decimal
/// - Currency + amount form a value
///
/// KEY RULE:
/// ❗ Primitive obsession causes bugs
/// </remarks>
public sealed class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    private Money() { } // EF Core

    public Money(decimal amount, string currency)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        Amount = amount;
        Currency = currency;
    }
}
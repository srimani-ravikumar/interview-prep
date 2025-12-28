namespace BackendMastery.Persistence.DataModeling.ValueObjects.Domain;

/// <summary>
/// Value Object representing monetary value.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Money has NO identity
/// - Two Money objects with same values are equal
/// - Immutable by design
///
/// KEY RULE:
/// - Equality is based on value, not reference
/// </remarks>
public readonly struct Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required.");

        Amount = amount;
        Currency = currency;
    }

    public override bool Equals(object? obj)
        => obj is Money other &&
           Amount == other.Amount &&
           Currency == other.Currency;

    public override int GetHashCode()
        => HashCode.Combine(Amount, Currency);

    public override string ToString()
        => $"{Amount} {Currency}";
}
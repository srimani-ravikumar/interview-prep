namespace BackendMastery.ECommerce.Domain.ValueObjects;

/// <summary>
/// Money is a value object.
/// Immutable, equality by value.
/// </summary>
public sealed class Money
{
    public decimal Amount { get; }

    private Money(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Money amount cannot be negative");

        Amount = amount;
    }

    public static Money Of(decimal amount)
        => new Money(amount);

    public static Money Zero()
        => new Money(0);

    public Money Add(Money other)
        => new Money(Amount + other.Amount);

    public Money Multiply(int factor)
        => new Money(Amount * factor);

    public override string ToString()
        => Amount.ToString("0.00");
}
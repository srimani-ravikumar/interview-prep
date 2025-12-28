namespace BackendMastery.Persistence.DataModeling.SchemaEvolution.Domain;

/// <summary>
/// Value object representing discount.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Introduced later in system lifecycle
/// - Domain grows without breaking old data
/// </remarks>
public readonly struct Discount
{
    public decimal Amount { get; }

    public Discount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Discount must be positive.");

        Amount = amount;
    }
}
namespace BackendMastery.Persistence.DataModeling.EntityIdentity.Domain;

/// <summary>
/// Strongly-typed identity for Order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Identity is not "just a Guid"
/// - Identity gives continuity across time
/// - Strong typing prevents accidental misuse
///
/// KEY RULE:
/// - Entities are defined by identity, not attributes
/// </remarks>
public readonly struct OrderId
{
    public Guid Value { get; }

    public OrderId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("OrderId cannot be empty.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
namespace BackendMastery.Persistence.DataModeling.ValueObjects.Domain;

public readonly struct OrderId
{
    public Guid Value { get; }

    public OrderId(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("OrderId cannot be empty.");

        Value = value;
    }
}
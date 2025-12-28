namespace BackendMastery.Persistence.DataModeling.MappingRules.Domain;

/// <summary>
/// Domain entity representing an Order.
/// </summary>
public class Order
{
    public OrderId Id { get; }
    public Money Total { get; }
    public Address ShippingAddress { get; }

    public Order(OrderId id, Money total, Address address)
    {
        Id = id;
        Total = total;
        ShippingAddress = address;
    }
}
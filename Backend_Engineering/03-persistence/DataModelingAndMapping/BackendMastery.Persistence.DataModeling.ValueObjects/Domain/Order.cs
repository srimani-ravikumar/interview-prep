namespace BackendMastery.Persistence.DataModeling.ValueObjects.Domain;

/// <summary>
/// Entity representing an Order.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Order is an entity (has identity)
/// - Money and Address are value objects
/// - Value objects are replaced, not mutated
/// </remarks>
public class Order
{
    public OrderId Id { get; }
    public Money Total { get; private set; }
    public Address ShippingAddress { get; private set; }

    public Order(OrderId id, Money total, Address address)
    {
        Id = id;
        Total = total;
        ShippingAddress = address;
    }

    public void UpdateAddress(Address newAddress)
    {
        ShippingAddress = newAddress; // Replace entirely
    }
}
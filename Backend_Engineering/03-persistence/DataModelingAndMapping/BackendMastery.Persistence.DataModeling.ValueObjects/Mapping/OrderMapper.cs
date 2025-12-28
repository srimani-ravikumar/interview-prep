using BackendMastery.Persistence.DataModeling.ValueObjects.Domain;
using BackendMastery.Persistence.DataModeling.ValueObjects.Storage;

namespace BackendMastery.Persistence.DataModeling.ValueObjects.Mapping;

/// <summary>
/// Maps Order entity and its value objects to storage.
/// </summary>
public static class OrderMapper
{
    public static OrderRecord ToRecord(Order order)
    {
        return new OrderRecord
        {
            Id = order.Id.Value,
            Amount = order.Total.Amount,
            Currency = order.Total.Currency,
            AddressLine1 = order.ShippingAddress.Line1,
            City = order.ShippingAddress.City,
            Country = order.ShippingAddress.Country
        };
    }

    public static Order ToDomain(OrderRecord record)
    {
        return new Order(
            new OrderId(record.Id),
            new Money(record.Amount, record.Currency),
            new Address(
                record.AddressLine1,
                record.City,
                record.Country
            )
        );
    }
}
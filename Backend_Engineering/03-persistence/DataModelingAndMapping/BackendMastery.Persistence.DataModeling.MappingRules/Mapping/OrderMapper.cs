using BackendMastery.Persistence.DataModeling.MappingRules.Domain;
using BackendMastery.Persistence.DataModeling.MappingRules.Storage;

namespace BackendMastery.Persistence.DataModeling.MappingRules.Mapping;

/// <summary>
/// Handles translation between domain and storage models.
/// </summary>
public static class OrderMapper
{
    public static (OrderRecord, AddressRecord) ToStorage(Order order)
    {
        var addressRecord = new AddressRecord
        {
            Id = Guid.NewGuid(),
            Line1 = order.ShippingAddress.Line1,
            City = order.ShippingAddress.City,
            Country = order.ShippingAddress.Country
        };

        var orderRecord = new OrderRecord
        {
            Id = order.Id.Value,
            Amount = order.Total.Amount,
            Currency = order.Total.Currency,
            AddressId = addressRecord.Id
        };

        return (orderRecord, addressRecord);
    }

    public static Order ToDomain(
        OrderRecord orderRecord,
        AddressRecord addressRecord)
    {
        return new Order(
            new OrderId(orderRecord.Id),
            new Money(orderRecord.Amount, orderRecord.Currency),
            new Address(
                addressRecord.Line1,
                addressRecord.City,
                addressRecord.Country
            )
        );
    }
}
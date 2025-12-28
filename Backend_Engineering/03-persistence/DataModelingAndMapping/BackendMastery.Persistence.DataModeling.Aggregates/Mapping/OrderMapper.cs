using BackendMastery.Persistence.DataModeling.Aggregates.Domain;
using BackendMastery.Persistence.DataModeling.Aggregates.Storage;

namespace BackendMastery.Persistence.DataModeling.Aggregates.Mapping;

/// <summary>
/// Maps Order aggregate to storage representation.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Mapping reconstructs the aggregate as a whole
/// - Partial loading is dangerous
/// </remarks>
public static class OrderMapper
{
    public static (OrderRecord, List<OrderItemRecord>) ToStorage(Order order)
    {
        var orderRecord = new OrderRecord
        {
            Id = order.Id.Value,
            TotalAmount = order.TotalAmount
        };

        var itemRecords = order.Items.Select(i => new OrderItemRecord
        {
            OrderId = order.Id.Value,
            Sku = i.Sku,
            Price = i.Price,
            Quantity = i.Quantity
        }).ToList();

        return (orderRecord, itemRecords);
    }
}
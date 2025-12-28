using BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Domain;
using BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Storage.Denormalized;
using BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Storage.Normalized;

namespace BackendMastery.Persistence.DataModeling.NormalizationTradeoffs.Mapping;

public static class OrderMapper
{
    public static (OrderRecord, List<OrderItemRecord>) ToNormalized(Order order)
    {
        var orderRecord = new OrderRecord { Id = order.Id.Value };

        var itemRecords = order.Items.Select(i => new OrderItemRecord
        {
            OrderId = order.Id.Value,
            Sku = i.Sku,
            Price = i.Price,
            Quantity = i.Quantity
        }).ToList();

        return (orderRecord, itemRecords);
    }

    public static OrderSummaryRecord ToSummary(Order order)
    {
        return new OrderSummaryRecord
        {
            OrderId = order.Id.Value,
            ItemCount = order.Items.Count,
            TotalAmount = order.TotalAmount
        };
    }
}
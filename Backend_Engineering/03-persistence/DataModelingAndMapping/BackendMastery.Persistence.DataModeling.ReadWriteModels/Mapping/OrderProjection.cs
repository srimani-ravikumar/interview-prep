using BackendMastery.Persistence.DataModeling.ReadWriteModels.Domain;
using BackendMastery.Persistence.DataModeling.ReadWriteModels.Storage.Read;

namespace BackendMastery.Persistence.DataModeling.ReadWriteModels.Mapping;

/// <summary>
/// Projects write model into read model.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Read models are derived
/// - Consistency is eventual
/// </remarks>
public static class OrderProjection
{
    public static OrderReadModel Project(Order order)
    {
        return new OrderReadModel
        {
            OrderId = order.Id.Value,
            ItemCount = order.Items.Count,
            TotalAmount = order.TotalAmount
        };
    }
}
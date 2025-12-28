using BackendMastery.Persistence.DataModeling.EntityIdentity.Domain;
using BackendMastery.Persistence.DataModeling.EntityIdentity.Storage;

namespace BackendMastery.Persistence.DataModeling.EntityIdentity.Mapping;

/// <summary>
/// Maps identity explicitly between domain and storage.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Identity is preserved across layers
/// - Mapping does NOT generate identity
/// </remarks>
public static class OrderMapper
{
    public static Order ToDomain(OrderRecord record)
    {
        return new Order(
            new OrderId(record.Id),
            record.Amount
        );
    }

    public static OrderRecord ToRecord(Order domain)
    {
        return new OrderRecord
        {
            Id = domain.Id.Value,
            Amount = domain.Amount,
            UpdatedAtUtc = DateTime.UtcNow
        };
    }
}
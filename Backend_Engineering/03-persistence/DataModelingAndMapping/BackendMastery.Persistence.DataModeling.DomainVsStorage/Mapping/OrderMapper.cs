using BackendMastery.Persistence.DataModeling.DomainVsStorage.Domain;
using BackendMastery.Persistence.DataModeling.DomainVsStorage.Storage;

namespace BackendMastery.Persistence.DataModeling.DomainVsStorage.Mapping;

/// <summary>
/// Translates between domain and storage models.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Mapping is a translation problem
/// - NOT a business logic problem
///
/// WHY THIS EXISTS:
/// - Prevents persistence leaking into domain
/// - Makes ORM / DB fully replaceable
/// </remarks>
public static class OrderMapper
{
    public static Order ToDomain(OrderRecord record)
    {
        return new Order(
            record.Id,
            record.Amount
        );
    }

    public static OrderRecord ToRecord(Order domain)
    {
        return new OrderRecord
        {
            Id = domain.Id,
            Amount = domain.Amount,
            CreatedAtUtc = DateTime.UtcNow,
            Status = Status.CREATED
        };
    }
}
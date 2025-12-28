using BackendMastery.Persistence.DataModeling.SchemaEvolution.Domain;
using BackendMastery.Persistence.DataModeling.SchemaEvolution.Storage;

namespace BackendMastery.Persistence.DataModeling.SchemaEvolution.Mapping;

/// <summary>
/// Maps multiple schema versions into the same domain model.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Domain stays stable
/// - Mapping absorbs schema differences
/// </remarks>
public static class OrderMapper
{
    public static Order FromV1(OrderRecordV1 record)
    {
        return new Order(
            new OrderId(record.Id),
            record.Amount,
            discount: null // v1 had no discount
        );
    }

    public static Order FromV2(OrderRecordV2 record)
    {
        return new Order(
            new OrderId(record.Id),
            record.Amount,
            record.DiscountAmount is null
                ? null
                : new Discount(record.DiscountAmount.Value)
        );
    }
}
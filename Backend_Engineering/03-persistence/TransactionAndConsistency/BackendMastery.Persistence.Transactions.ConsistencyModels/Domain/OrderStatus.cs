namespace BackendMastery.Persistence.Transactions.ConsistencyModels.Domain;

/// <summary>
/// Represents order lifecycle.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Status changes are progressive
/// - Missing an update temporarily is acceptable
/// </remarks>
public enum OrderStatus
{
    Placed,
    Shipped,
    Delivered
}
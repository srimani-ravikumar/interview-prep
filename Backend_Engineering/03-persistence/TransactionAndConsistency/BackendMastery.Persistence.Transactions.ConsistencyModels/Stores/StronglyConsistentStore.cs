using BackendMastery.Persistence.Transactions.ConsistencyModels.Domain;

namespace BackendMastery.Persistence.Transactions.ConsistencyModels.Stores;

/// <summary>
/// Simulates strong consistency.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Reads always return latest write
/// - Slower but safe
///
/// USE CASE:
/// - Payments
/// - Order creation
/// - Inventory checks
///
/// KEY RULE:
/// ❗ Use only where correctness is mandatory
/// </remarks>
public class StronglyConsistentStore
{
    private readonly Dictionary<Guid, OrderStatus> _store = new();

    public void Write(Guid orderId, OrderStatus status)
    {
        _store[orderId] = status;
    }

    public OrderStatus Read(Guid orderId)
    {
        return _store[orderId];
    }
}
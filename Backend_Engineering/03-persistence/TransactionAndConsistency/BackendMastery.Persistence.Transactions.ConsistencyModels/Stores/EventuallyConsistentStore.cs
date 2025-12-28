using BackendMastery.Persistence.Transactions.ConsistencyModels.Domain;

namespace BackendMastery.Persistence.Transactions.ConsistencyModels.Stores;

/// <summary>
/// Simulates eventual consistency.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Reads may return stale data
/// - System converges over time
///
/// USE CASE:
/// - Notifications
/// - Dashboards
/// - Search results
///
/// KEY RULE:
/// ❗ Users must tolerate slight staleness
/// </remarks>
public class EventuallyConsistentStore
{
    private readonly Dictionary<Guid, OrderStatus> _store = new();

    public void WriteAsync(Guid orderId, OrderStatus status)
    {
        Task.Run(async () =>
        {
            await Task.Delay(1000); // simulate propagation delay
            _store[orderId] = status;
        });
    }

    public OrderStatus? Read(Guid orderId)
    {
        _store.TryGetValue(orderId, out var status);
        return status;
    }
}
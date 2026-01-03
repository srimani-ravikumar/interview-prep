using System.Collections.Concurrent;

namespace BackendMastery.ProdReadiness.Idempotency.Infrastructure;

/// <summary>
/// Stores processed idempotency keys and their results.
///
/// WHY THIS EXISTS:
/// The system must remember which requests
/// were already successfully processed.
///
/// WHAT PROBLEM THIS SOLVES:
/// Prevents duplicate side effects during retries.
///
/// WHEN TO USE:
/// Every retry-safe write operation.
///
/// WHAT BREAKS IF MISUSED:
/// Short-lived or non-persistent stores allow replays.
/// </summary>
public sealed class InMemoryIdempotencyStore
{
    private readonly ConcurrentDictionary<string, object> _store = new();

    public bool TryGet(string key, out object result)
        => _store.TryGetValue(key, out result!);

    public void Store(string key, object result)
        => _store[key] = result;
}
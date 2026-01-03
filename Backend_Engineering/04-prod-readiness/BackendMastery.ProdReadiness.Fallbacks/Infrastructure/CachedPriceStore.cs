using System.Collections.Concurrent;
using BackendMastery.ProdReadiness.Fallbacks.Contracts;

namespace BackendMastery.ProdReadiness.Fallbacks.Infrastructure;

/// <summary>
/// Stores last known good prices.
///
/// WHY THIS EXISTS:
/// Cached data enables safe fallback
/// for pricing failures.
///
/// WHAT BREAKS IF MISUSED:
/// Long-lived stale prices cause revenue loss.
/// </summary>
public sealed class CachedPriceStore
{
    private readonly ConcurrentDictionary<string, PriceInfo> _cache = new();

    public void Store(string productId, PriceInfo price)
        => _cache[productId] = price;

    public bool TryGet(string productId, out PriceInfo price)
        => _cache.TryGetValue(productId, out price!);
}
using BackendMastery.ProdReadiness.Fallbacks.Contracts;
using BackendMastery.ProdReadiness.Fallbacks.Infrastructure;

namespace BackendMastery.ProdReadiness.Fallbacks.Services;

/// <summary>
/// Coordinates product data with fallback strategies.
///
/// WHY THIS EXISTS:
/// Business decides what degrades and how.
///
/// FALLBACK RULES:
/// - Price failure → cached price
/// - Recommendation failure → empty list
///
/// WHAT BREAKS IF MISUSED:
/// Hiding degradation misleads users and ops.
/// </summary>
public sealed class ProductService : IProductService
{
    private readonly PricingClient _pricing;
    private readonly RecommendationClient _recommendations;
    private readonly CachedPriceStore _cache;

    public ProductService(
        PricingClient pricing,
        RecommendationClient recommendations,
        CachedPriceStore cache)
    {
        _pricing = pricing;
        _recommendations = recommendations;
        _cache = cache;
    }

    public async Task<ProductResponse> GetAsync(
        string productId,
        CancellationToken cancellationToken)
    {
        PriceInfo price;

        try
        {
            var amount = await _pricing
                .GetPriceAsync(productId, cancellationToken);

            price = new PriceInfo(amount, IsFromCache: false);
            _cache.Store(productId, price);
        }
        catch
        {
            if (!_cache.TryGet(productId, out price))
                throw; // No safe fallback available
        }

        IReadOnlyList<string> recs;

        try
        {
            recs = await _recommendations
                .GetAsync(productId, cancellationToken);
        }
        catch
        {
            // Non-critical feature → safe degradation
            recs = Array.Empty<string>();
        }

        return new ProductResponse(
            ProductId: productId,
            Price: price,
            Recommendations: recs);
    }
}
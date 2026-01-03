using BackendMastery.ProdReadiness.Fallbacks.Contracts;

namespace BackendMastery.ProdReadiness.Fallbacks.Services;

/// <summary>
/// Product retrieval contract.
///
/// WHY THIS EXISTS:
/// Encapsulates fallback decisions
/// away from HTTP concerns.
/// </summary>
public interface IProductService
{
    Task<ProductResponse> GetAsync(
        string productId,
        CancellationToken cancellationToken);
}
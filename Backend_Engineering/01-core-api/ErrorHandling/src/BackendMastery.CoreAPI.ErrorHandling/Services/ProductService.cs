using BackendMastery.CoreAPI.ErrorHandling.Exceptions;
using BackendMastery.CoreAPI.ErrorHandling.Models;

namespace BackendMastery.CoreAPI.ErrorHandling.Services;

public class ProductService
{
    private static readonly List<Product> _products = new();

    // -----------------------------
    // FAIL FAST
    // -----------------------------

    /// <summary>
    /// Fail-fast example.
    /// </summary>
    /// <remarks>
    /// Intuition:
    /// - Detect invalid input immediately
    /// - Prevents corrupt state propagation
    ///
    /// Use case:
    /// - Financial transactions
    /// - Inventory updates
    /// </remarks>
    public Product GetProductFailFast(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Product id cannot be empty.");

        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is null)
            throw new ResourceNotFoundException(nameof(Product), id);

        return product;
    }

    // -----------------------------
    // FAIL SAFE
    // -----------------------------

    /// <summary>
    /// Fail-safe example.
    /// </summary>
    /// <remarks>
    /// Intuition:
    /// - System continues operating with fallback
    ///
    /// Use case:
    /// - Search suggestions
    /// - Recommendation systems
    /// </remarks>
    public Product GetProductFailSafe(string id)
    {
        try
        {
            return GetProductFailFast(id);
        }
        catch
        {
            // fallback behavior
            return new Product
            {
                Id = "fallback",
                Name = "Default Product"
            };
        }
    }
}
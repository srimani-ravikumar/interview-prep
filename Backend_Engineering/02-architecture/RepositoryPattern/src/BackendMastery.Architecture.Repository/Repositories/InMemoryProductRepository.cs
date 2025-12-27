using BackendMastery.Architecture.Repository.Models;

namespace BackendMastery.Architecture.Repository.Repositories;

/// <summary>
/// In-memory repository implementation.
/// </summary>
/// <remarks>
/// Intuition:
/// - Implements data access contract
/// - Knows WHERE data lives
///
/// This class:
/// - CAN know storage details
/// - MUST NOT leak them outward
/// </remarks>
public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new()
    {
        new() { Id = "P1", Name = "Keyboard" },
        new() { Id = "P2", Name = "Mouse" }
    };

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(string id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}
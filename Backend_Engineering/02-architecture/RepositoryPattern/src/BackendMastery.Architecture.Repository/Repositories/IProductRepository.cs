using BackendMastery.Architecture.Repository.Models;

namespace BackendMastery.Architecture.Repository.Repositories;

/// <summary>
/// Repository abstraction.
/// </summary>
/// <remarks>
/// Intuition:
/// - Defines WHAT data operations are needed
/// - Hides HOW data is retrieved
///
/// Use cases:
/// - Swap storage implementation
/// - Enable testing without real storage
/// - Isolate persistence details
/// </remarks>
public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product? GetById(string id);
}
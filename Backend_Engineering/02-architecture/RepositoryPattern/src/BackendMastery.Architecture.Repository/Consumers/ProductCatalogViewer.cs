using BackendMastery.Architecture.Repository.Repositories;

namespace BackendMastery.Architecture.Repository.Consumers;

/// <summary>
/// Consumer of repository.
/// </summary>
/// <remarks>
/// Intuition:
/// - This class USES data
/// - It does not care WHERE data comes from
///
/// This is NOT:
/// - a service
/// - a controller
///
/// It simply demonstrates repository usage
/// </remarks>
public class ProductCatalogViewer
{
    private readonly IProductRepository _repository;

    public ProductCatalogViewer(IProductRepository repository)
    {
        _repository = repository;
    }

    public void DisplayAll()
    {
        foreach (var product in _repository.GetAll())
        {
            Console.WriteLine($"{product.Id} - {product.Name}");
        }
    }
}
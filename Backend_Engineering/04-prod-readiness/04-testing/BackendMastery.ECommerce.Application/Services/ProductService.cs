using BackendMastery.ECommerce.Application.Interfaces;
using BackendMastery.ECommerce.Domain.Entities;
using BackendMastery.ECommerce.Domain.ValueObjects;

namespace BackendMastery.ECommerce.Application.Services;

/// <summary>
/// Handles product-related use cases.
/// </summary>
public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> CreateProductAsync(
        string name,
        decimal price)
    {
        var product = new Product(
            Guid.NewGuid(),
            name,
            Money.Of(price));

        await _productRepository.AddAsync(product);
        return product.Id;
    }
}
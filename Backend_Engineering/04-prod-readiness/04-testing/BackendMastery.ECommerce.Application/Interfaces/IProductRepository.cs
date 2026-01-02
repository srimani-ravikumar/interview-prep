using BackendMastery.ECommerce.Domain.Entities;

namespace BackendMastery.ECommerce.Application.Interfaces;

/// <summary>
/// Abstraction over product persistence.
/// Application does NOT care how data is stored.
/// </summary>
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
}
namespace BackendMastery.ECommerce.API.Contracts.Products;

/// <summary>
/// Response contract for product.
/// </summary>
public record ProductResponse(
    Guid Id,
    string Name,
    decimal Price
);
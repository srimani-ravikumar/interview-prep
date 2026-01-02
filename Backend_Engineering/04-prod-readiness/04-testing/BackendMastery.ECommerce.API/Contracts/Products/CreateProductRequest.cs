namespace BackendMastery.ECommerce.API.Contracts.Products;

/// <summary>
/// Request contract for creating a product.
/// </summary>
public record CreateProductRequest(
    string Name,
    decimal Price
);
namespace BackendMastery.CoreAPI.CRUDBasics.Database.Models;

/// <summary>
/// Represents request body for creating or updating a product.
/// Not a DTO — just a request model for binding.
/// </summary>
public class ProductCreateUpdateRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
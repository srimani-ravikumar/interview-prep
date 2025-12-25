using BackendMastery.CoreAPI.CRUDBasics.InMemory.Models;

namespace BackendMastery.CoreAPI.CRUDBasics.InMemory.Services;

/// <summary>
/// Defines business operations related to <see cref="Product"/> entities.
/// </summary>
/// <remarks>
/// <para>
/// This interface represents the <b>service layer</b>, which contains
/// application-specific business rules and orchestration logic.
/// </para>
/// <para>
/// Controllers should remain thin and delegate all business decisions
/// such as validation, creation, and update rules to this layer.
/// </para>
/// <para>
/// The service layer typically coordinates between repositories,
/// applies domain rules, and returns results in a form suitable for
/// the API layer.
/// </para>
/// </remarks>
public interface IProductService
{
    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>
    /// An enumerable collection of all <see cref="Product"/> entities.
    /// </returns>
    IEnumerable<Product> GetAll();

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product to retrieve.
    /// </param>
    /// <returns>
    /// The matching <see cref="Product"/> if found; otherwise, <c>null</c>.
    /// </returns>
    Product? GetById(Guid id);

    /// <summary>
    /// Creates a new product by applying business validation rules.
    /// </summary>
    /// <param name="name">
    /// The name of the product.
    /// </param>
    /// <param name="price">
    /// The price of the product.
    /// </param>
    /// <returns>
    /// The newly created <see cref="Product"/> entity.
    /// </returns>
    Product Create(string name, decimal price);

    /// <summary>
    /// Updates an existing product by applying business rules.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product to update.
    /// </param>
    /// <param name="name">
    /// The updated name of the product.
    /// </param>
    /// <param name="price">
    /// The updated price of the product.
    /// </param>
    /// <returns>
    /// <c>true</c> if the product was updated successfully;
    /// otherwise, <c>false</c> if the product was not found.
    /// </returns>
    bool Update(Guid id, string name, decimal price);

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product to delete.
    /// </param>
    /// <returns>
    /// <c>true</c> if the product was deleted successfully;
    /// otherwise, <c>false</c> if the product was not found.
    /// </returns>
    bool Delete(Guid id);
}
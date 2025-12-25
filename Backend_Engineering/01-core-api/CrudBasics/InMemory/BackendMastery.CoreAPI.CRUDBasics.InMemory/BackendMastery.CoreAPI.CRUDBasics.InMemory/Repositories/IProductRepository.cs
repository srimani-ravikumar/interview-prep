using BackendMastery.CoreAPI.CRUDBasics.InMemory.Models;

namespace BackendMastery.CoreAPI.CRUDBasics.InMemory.Repositories;

/// <summary>
/// Defines a contract for accessing and managing <see cref="Product"/> data.
/// </summary>
/// <remarks>
/// <para>
/// This interface represents the <b>Repository abstraction</b>, which decouples
/// the application from the underlying data storage mechanism.
/// </para>
/// <para>
/// Consumers such as controllers and services interact with this contract
/// without knowing whether data is stored in memory, a database, or any other medium.
/// </para>
/// <para>
/// This abstraction improves testability, maintainability, and adherence
/// to the Dependency Inversion Principle.
/// </para>
/// </remarks>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves all products from the data store.
    /// </summary>
    /// <returns>
    /// An enumerable collection containing all <see cref="Product"/> entities.
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
    /// Adds a new product to the data store.
    /// </summary>
    /// <param name="product">
    /// The <see cref="Product"/> entity to add.
    /// </param>
    void Add(Product product);

    /// <summary>
    /// Updates an existing product in the data store.
    /// </summary>
    /// <param name="product">
    /// The <see cref="Product"/> entity containing updated data.
    /// </param>
    void Update(Product product);

    /// <summary>
    /// Removes a product from the data store using its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the product to delete.
    /// </param>
    void Delete(Guid id);
}
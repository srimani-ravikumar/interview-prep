using BackendMastery.CoreAPI.CRUDBasics.Database.Models;

namespace BackendMastery.CoreAPI.CRUDBasics.Database.Repositories;

/// <summary>
/// Defines a contract for accessing and managing <see cref="Product"/> data
/// using a database-backed persistence mechanism.
/// </summary>
/// <remarks>
/// <para>
/// This interface represents the <b>Repository abstraction</b> for database
/// operations and hides all persistence-specific details such as ORM usage,
/// database connections, and transaction handling.
/// </para>
/// <para>
/// Higher layers interact with this contract without knowing whether
/// the implementation uses Entity Framework, Dapper, or any other data access strategy.
/// </para>
/// <para>
/// The presence of an explicit <see cref="SaveChanges"/> method indicates
/// a unit-of-work style interaction commonly used with ORM-based repositories.
/// </para>
/// </remarks>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves all products from the database.
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
    /// Adds a new product to the database context.
    /// </summary>
    /// <param name="product">
    /// The <see cref="Product"/> entity to be tracked and inserted.
    /// </param>
    /// <remarks>
    /// This operation typically marks the entity for insertion.
    /// The actual database write is deferred until <see cref="SaveChanges"/> is called.
    /// </remarks>
    void Add(Product product);

    /// <summary>
    /// Updates an existing product in the database context.
    /// </summary>
    /// <param name="product">
    /// The <see cref="Product"/> entity containing updated values.
    /// </param>
    /// <remarks>
    /// This operation marks the entity as modified.
    /// Changes are persisted to the database only when
    /// <see cref="SaveChanges"/> is invoked.
    /// </remarks>
    void Update(Product product);

    /// <summary>
    /// Removes an existing product from the database context.
    /// </summary>
    /// <param name="product">
    /// The <see cref="Product"/> entity to remove.
    /// </param>
    /// <remarks>
    /// The entity is marked for deletion.
    /// The actual delete operation occurs when <see cref="SaveChanges"/> is called.
    /// </remarks>
    void Delete(Product product);

    /// <summary>
    /// Persists all pending changes to the database.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method commits all tracked changes such as inserts, updates,
    /// and deletions as a single unit of work.
    /// </para>
    /// <para>
    /// Keeping this operation explicit provides better control over
    /// transaction boundaries and improves testability.
    /// </para>
    /// </remarks>
    void SaveChanges();
}
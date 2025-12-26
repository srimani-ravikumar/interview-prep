using BackendMastery.CoreAPI.CRUDBasics.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendMastery.CoreAPI.CRUDBasics.Database.Data;

/// <summary>
/// Represents a session with the database.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="DbContext"/> acts as a <b>Unit of Work</b>, meaning it:
/// - Tracks entity changes (Added, Modified, Deleted)
/// - Coordinates database writes as a single transaction
/// - Provides a boundary for consistency
/// </para>
/// <para>
/// A single instance of <see cref="AppDbContext"/> typically lives for the
/// duration of one request in a web application.
/// </para>
/// </remarks>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new database context with configured options.
    /// </summary>
    /// <param name="options">
    /// Database configuration such as provider, connection string,
    /// and behavior settings.
    /// </param>
    /// <remarks>
    /// The framework injects these options via Dependency Injection.
    /// This keeps the context configuration centralized and environment-specific.
    /// </remarks>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Represents the Products table in the database.
    /// Each DbSet represents a table
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="DbSet{TEntity}"/>:
    /// - Maps a domain entity to a database table
    /// - Enables LINQ queries that translate to SQL
    /// - Allows change tracking for persistence
    /// </para>
    /// <para>
    /// Accessing this property does not hit the database immediately.
    /// Queries are executed only when enumerated.
    /// </para>
    /// </remarks>

    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Configures entity mappings and database constraints.
    /// </summary>
    /// <param name="modelBuilder">
    /// Provides a fluent API to configure entity behavior and schema.
    /// </param>
    /// <remarks>
    /// <para>
    /// This method is executed once during model creation
    /// and defines how CLR entities map to database structures.
    /// </para>
    /// <para>
    /// Fluent API configuration is preferred here over data annotations
    /// to keep domain models free from persistence concerns.
    /// </para>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            /// <summary>
            /// Defines the primary key for the Product table.
            /// </summary>
            entity.HasKey(p => p.Id);

            /// <summary>
            /// Enforces a NOT NULL constraint on the Name column.
            /// </summary>
            entity.Property(p => p.Name).IsRequired();

            /// <summary>
            /// Configures precision and scale for monetary values.
            /// </summary>
            /// <remarks>
            /// Using decimal with explicit precision avoids rounding
            /// and floating-point errors in financial calculations.
            /// </remarks>
            entity.Property(p => p.Price).HasPrecision(18, 2);
        });
    }
}
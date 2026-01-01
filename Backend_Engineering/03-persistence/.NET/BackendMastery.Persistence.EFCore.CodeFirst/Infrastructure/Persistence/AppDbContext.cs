using BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Infrastructure.Persistence;

/// <summary>
/// EF Core DbContext = Unit of Work.
/// </summary>
/// <remarks>
/// INTUITION:
/// - DbContext tracks changes
/// - Controls transaction boundary
///
/// KEY RULE:
/// ❗ DbContext is NOT a repository
/// </remarks>
public class AppDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}
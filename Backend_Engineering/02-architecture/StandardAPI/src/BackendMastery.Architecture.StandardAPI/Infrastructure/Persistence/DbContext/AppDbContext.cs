using BackendMastery.Architecture.StandardAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BackendMastery.Architecture.StandardAPI.Infrastructure.Persistence.DbContext;

/// <summary>
/// EF Core DbContext.
/// </summary>
/// <remarks>
/// <para>
/// Intuition:
/// - Represents the database session
/// - Knows how domain entities map to tables
/// </para>
/// <para>
/// This class:
/// - Belongs to Infrastructure
/// - Depends on Domain models
/// </para>
/// <para>
/// Domain does NOT depend on this.
/// </para>
/// </remarks>
public class AppDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Amount)
                  .IsRequired();

            entity.Property(o => o.IsPriority)
                  .IsRequired();

            entity.Property(o => o.IsApproved)
                  .IsRequired();
        });
    }
}
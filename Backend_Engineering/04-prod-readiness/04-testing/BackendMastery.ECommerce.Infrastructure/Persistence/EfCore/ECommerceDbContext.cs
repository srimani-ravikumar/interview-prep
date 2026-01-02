using BackendMastery.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BackendMastery.ECommerce.Infrastructure.Persistence.EfCore;

/// <summary>
/// EF Core DbContext for e-commerce.
/// </summary>
public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // PRODUCT
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                  .IsRequired();

            // Money is a VALUE OBJECT
            entity.OwnsOne(p => p.Price, money =>
            {
                money.Property(m => m.Amount)
                     .HasColumnName("Price")
                     .IsRequired();
            });
        });

        // ORDER
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.OwnsMany(o => o.Items, items =>
            {
                items.WithOwner();

                items.Property<int>("Id");
                items.HasKey("Id");

                items.Property(i => i.Quantity)
                     .IsRequired();

                items.Navigation(i => i.Product)
                     .UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        });
    }


}
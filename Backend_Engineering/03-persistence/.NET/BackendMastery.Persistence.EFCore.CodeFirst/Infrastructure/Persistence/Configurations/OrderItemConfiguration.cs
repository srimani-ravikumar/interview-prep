using BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core mapping for OrderItem.
/// </summary>
/// <remarks>
/// INTUITION:
/// - OrderItem is a dependent entity
/// - Exists only within Order aggregate
///
/// KEY RULE:
/// ❗ Dependent entities must be explicitly configured
/// </remarks>
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ProductName)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(i => i.Quantity)
               .IsRequired();

        // Foreign key is owned by Order aggregate
        builder.Property<Guid>("OrderId");

        builder.HasIndex("OrderId");

        builder.ToTable("OrderItems");
    }
}
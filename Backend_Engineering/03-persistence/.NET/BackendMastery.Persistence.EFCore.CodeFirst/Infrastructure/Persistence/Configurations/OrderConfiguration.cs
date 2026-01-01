using BackendMastery.Persistence.EFCore.CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendMastery.Persistence.EFCore.CodeFirst.Infrastructure.Persistence.Configurations;

/// <summary>
/// Explicit EF Core mapping.
/// </summary>
/// <remarks>
/// INTUITION:
/// - Fluent config > data annotations
/// - Database enforces invariants
///
/// KEY RULE:
/// ❗ Never rely on EF defaults in production
/// </remarks>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.OwnsOne(o => o.Total, money =>
        {
            money.Property(m => m.Amount)
                 .HasPrecision(18, 2)
                 .IsRequired();

            money.Property(m => m.Currency)
                 .HasMaxLength(3)
                 .IsRequired();
        });

        builder.Property(o => o.CreatedAt)
               .IsRequired();

        builder.HasMany(o => o.Items)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(30).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).HasMaxLength(30).IsRequired(false);
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Url).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Tag).IsRequired().HasMaxLength(100);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
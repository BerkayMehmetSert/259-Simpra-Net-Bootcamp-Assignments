using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staff").HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(40);
            builder.Property(x => x.DateOfBirth).IsRequired(true);
            builder.Property(x => x.AddressLine1).IsRequired(true).HasMaxLength(150);
            builder.Property(x => x.City).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Province).IsRequired(true).HasMaxLength(50);

            builder.HasIndex(x => x.Email).IsUnique(true);
        }
    }
}

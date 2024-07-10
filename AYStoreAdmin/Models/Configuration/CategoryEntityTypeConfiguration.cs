using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYStoreAdmin.Models.Configuration
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name)
                 .IsRequired();

            builder.Property(p => p.Description)
                    .HasMaxLength(1000);
        }
    }
}

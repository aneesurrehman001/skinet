using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// This class is for setting up the migrations according to our requirements

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureURL).IsRequired();
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(b => b.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(t => t.ProductTypeId);
        }
    }
}
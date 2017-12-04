using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models;

namespace ProductShop.Data.EntityConfig
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(cp => new {cp.CategoryId, cp.ProductId});
            builder.HasOne(e => e.Category)
                .WithMany(e => e.CategoryProducts)
                .HasForeignKey(e => e.CategoryId);
            builder.HasOne(e => e.Product)
                .WithMany(e => e.CategoryProducts)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
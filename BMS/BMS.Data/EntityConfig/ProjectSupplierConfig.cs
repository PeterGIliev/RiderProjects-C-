using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class ProjectSupplierConfig : IEntityTypeConfiguration<ProjectSupplier>
    {
        public void Configure(EntityTypeBuilder<ProjectSupplier> builder)
        {
            builder.HasKey(e => new {e.ProjectId, e.SupplierId});

            builder.HasOne(e => e.Project)
                .WithMany(p => p.ProjectSuppliers)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.ProjectSuppliers)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
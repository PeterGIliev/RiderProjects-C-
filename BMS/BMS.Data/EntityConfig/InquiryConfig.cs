using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class InquiryConfig : IEntityTypeConfiguration<Inquire>
    {
        public void Configure(EntityTypeBuilder<Inquire> builder)
        {
            builder.HasOne(e => e.Project)
                .WithMany(p => p.Inquires)
                .HasForeignKey(e => e.ProjectId);
        }
    }
}
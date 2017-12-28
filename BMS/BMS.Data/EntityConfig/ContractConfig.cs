using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasOne(e => e.Creator)
                .WithMany(c => c.Contracts)
                .HasForeignKey(e => e.CreatorId);
            
            builder.HasOne(e => e.Project)
                .WithMany(c => c.Contracts)
                .HasForeignKey(e => e.ProjectId);
        }
    }
}
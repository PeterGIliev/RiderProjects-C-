using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class OfferConfig : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasOne(e => e.Creator)
                .WithMany(c => c.Offers)
                .HasForeignKey(e => e.CreatorId);
            
            builder.HasOne(e => e.Project)
                .WithMany(c => c.Offers)
                .HasForeignKey(e => e.ProjectId);
        }
    }
}
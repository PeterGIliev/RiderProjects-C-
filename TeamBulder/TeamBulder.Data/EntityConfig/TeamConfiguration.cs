using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBulder.Data.EntityConfig
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();;
            builder.Property(e => e.Name).HasColumnType("nvarchar(25)").IsRequired(true);
            builder.Property(e => e.Description).HasColumnType("nvarchar(32)").IsRequired(false);
            builder.Property(e => e.Acronym).IsRequired(true);
            builder.HasOne(e => e.Creator)
                .WithMany(c => c.TeamsCreated)
                .HasForeignKey(e => e.CreatorId);
        }
    }
}
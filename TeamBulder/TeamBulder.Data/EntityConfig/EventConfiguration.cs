using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBulder.Data.EntityConfig
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("nvarchar(25)").IsRequired(true);
            builder.Property(e => e.Description).HasColumnType("nvarchar(250)").IsRequired(true);
            builder.Property(e => e.StartDate).HasColumnType("DATETIME2");
            builder.Property(e => e.EndDate).HasColumnType("DATETIME2");
            builder.HasOne(e => e.Creator)
                .WithMany(c => c.EventsCreated)
                .HasForeignKey(e => e.CreatorId);
        }
    }
}
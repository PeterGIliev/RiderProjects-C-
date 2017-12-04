using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfig
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired(true);
            builder.Property(e => e.Town).HasColumnType("nvarchar(50)").IsRequired(false);
        }
    }
}
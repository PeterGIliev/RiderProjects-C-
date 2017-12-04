using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfig
{
    public class SeatingClassConfiguration : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasColumnType("nvarchar(30)").IsRequired(true);
            builder.Property(e => e.Abbreviation).HasColumnType("nvarchar(2)").IsRequired(true);
        }
    }
}
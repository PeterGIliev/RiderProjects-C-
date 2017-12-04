using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfig
{
    public class CustomerCardConfiguration : IEntityTypeConfiguration<CustomerCard>
    {
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("nvarchar(128)").IsRequired(true);
            builder.Property(e => e.Age).HasColumnType("int");
            builder.Property(e => e.CardType).HasDefaultValue("Normal");
        }
    }
}
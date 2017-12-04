using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBulder.Data.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username).IsRequired(true);
            builder.HasIndex(e => e.Username).IsUnique();
            builder.Property(e => e.FirstName).HasMaxLength(25).IsRequired(false);
            builder.Property(e => e.LastName).HasMaxLength(25).IsRequired(false);
            builder.Property(e => e.Password).HasColumnType("varchar(30)")
                .IsRequired(true);
        }
    }
}
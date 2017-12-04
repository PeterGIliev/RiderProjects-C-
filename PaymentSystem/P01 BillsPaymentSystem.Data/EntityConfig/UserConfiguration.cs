using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.LastName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.Email).HasColumnType("varchar(80)").IsRequired();
            builder.Property(e => e.Password).HasColumnType("varchar(25)").IsRequired();
        }
    }
}
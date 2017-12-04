using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            
              builder.HasKey(e => e.BankAccountId);
              builder.Property(e => e.Balance).IsRequired();
              builder.Ignore(e => e.PaymentMethodId);
              builder.Property(e => e.BankName).HasColumnType("nvarchar(50)").IsRequired();
              builder.Property(e => e.SWIFTCode).HasColumnType("varchar(20)").IsRequired();
            
        }
    }
}
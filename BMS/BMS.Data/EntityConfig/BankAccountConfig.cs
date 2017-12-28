using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasOne(e => e.AccountOwnerClient)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(e => e.ClientId);
            
            builder.HasOne(e => e.AccountOwnerSupplier)
                .WithMany(c => c.BankAccounts)
                .HasForeignKey(e => e.SupplierId);
        }
    }
}
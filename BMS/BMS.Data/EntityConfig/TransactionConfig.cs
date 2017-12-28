using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(e => e.Client)
                .WithMany(c => c.Transactions)
                .HasForeignKey(e => e.ClientId);
            
            builder.HasOne(e => e.Supplier)
                .WithMany(c => c.Transactions)
                .HasForeignKey(e => e.SupplierId);
        }
    }
}
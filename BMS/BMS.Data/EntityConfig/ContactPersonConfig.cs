using BMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.EntityConfig
{
    public class ContactPersonConfig : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.HasOne(e => e.ClientContact)
                .WithMany(c => c.ContactPersons)
                .HasForeignKey(e => e.ClientId);
            
            builder.HasOne(e => e.SupplierContact)
                .WithMany(c => c.ContactPersons)
                .HasForeignKey(e => e.SupplierId);
        }
    }
}
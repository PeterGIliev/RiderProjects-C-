using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models;

namespace ProductShop.Data.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired(false);
//            builder.Ignore(e => e.FriendId);
//            builder.HasOne(e => e.Friend)
//                .WithMany(p => p.Friends)
//                .HasForeignKey(d => d.FriendId)
//                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
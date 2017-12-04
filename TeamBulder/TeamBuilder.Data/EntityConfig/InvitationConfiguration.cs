using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBulder.Data.EntityConfig
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Team)
                .WithMany(t => t.Invitations)
                .HasForeignKey(e => e.TeamId);
            builder.HasOne(e => e.InvitedUser)
                .WithMany(t => t.Invitations)
                .HasForeignKey(e => e.InvitedUserId);

        }
    }
}
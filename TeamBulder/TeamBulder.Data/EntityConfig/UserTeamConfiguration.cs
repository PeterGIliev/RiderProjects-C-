using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBulder.Data.EntityConfig
{
    public class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.HasKey(e => new {e.UserId, e.TeamId});

            builder.HasOne(e => e.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(e => e.TeamId);
            
            builder.HasOne(e => e.User)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
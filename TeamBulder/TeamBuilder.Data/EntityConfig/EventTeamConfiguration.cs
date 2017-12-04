using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBulder.Data.EntityConfig
{
    public class EventTeamConfiguration : IEntityTypeConfiguration<EventTeam>
    {
        public void Configure(EntityTypeBuilder<EventTeam> builder)
        {
            builder.HasKey(e => new {e.TeamId, e.EventId});
            
            builder.HasOne(e => e.Team)
                .WithMany(t => t.EventTeams)
                .HasForeignKey(e => e.TeamId);
            
            builder.HasOne(e => e.Event)
                .WithMany(t => t.EventTeams)
                .HasForeignKey(e => e.EventId);

        }
    }
}
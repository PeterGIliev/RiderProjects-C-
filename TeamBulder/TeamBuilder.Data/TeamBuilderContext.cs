using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using TeamBuilder.Models;
using TeamBulder.Data.EntityConfig;

namespace TeamBulder.Data
{
    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
        {
            
        }
        
        public TeamBuilderContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        
        public DbSet<EventTeam> EventTeams { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTeam> UserTeams { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new EventTeamConfiguration());
            builder.ApplyConfiguration(new InvitationConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new UserTeamConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
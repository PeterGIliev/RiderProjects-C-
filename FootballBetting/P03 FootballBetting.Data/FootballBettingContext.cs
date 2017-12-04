using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
            
        }

        public FootballBettingContext(DbContextOptions options)
        :base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(80)");

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasColumnType("NCHAR(3)");

                entity.HasOne(e => e.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(e => e.TownId);

                entity.HasOne(e => e.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(e => e.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(e => e.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");
                
                
            });

            builder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(80)");

                entity.HasOne(e => e.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(e => e.CountryId);
            });

            builder.Entity<Player>(entity =>
            {
                entity.HasOne(e => e.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(e => e.TeamId);
                
                entity.HasOne(e => e.Position)
                    .WithMany(t => t.Players)
                    .HasForeignKey(e => e.PositionId);
            });

            builder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new {e.GameId, e.PlayerId});
                
                entity.HasOne(e => e.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(e => e.PlayerId);
                
                entity.HasOne(e => e.Game)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(e => e.GameId);
                
                
            });

            builder.Entity<Game>(entity =>
            {
                entity.HasOne(e => e.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(e => e.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(e => e.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Bet>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(e => e.UserId);
                
                entity.HasOne(e => e.Game)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(e => e.GameId);
            });
        }
        
        
    }
}
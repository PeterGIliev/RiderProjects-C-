using System;
using Cars.Data.Models;
using Cars.Data.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
        {
            
        }

        public CarsDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
        
        public DbSet<Make> Makes { get; set; }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Dealership> Dealerships { get; set; }

        public DbSet<CarDealership> CarDealerships { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<LicensePlate> LicensePlates { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=Cars ;User ID=sa;Password=Peter@76545759");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new EngineConfiguration());           
            builder.ApplyConfiguration(new CarDealershipConfiguration());
            
            

        }
    }
}
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {

        public SalesContext()
        {
            
        }
        
        public SalesContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
             
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {           

            builder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Name).HasColumnType("nvarchar(100)");
                entity.Property(c => c.Email).HasColumnType("varchar(80)");
                entity.HasMany(c => c.Sales)
                      .WithOne(s => s.Customer)
                      .HasForeignKey(s => s.CustomerId);
            });
            
            builder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).HasColumnType("nvarchar(50)");
                entity.Property(p => p.Description).HasColumnType("nvarchar(250)").HasDefaultValue("No description");
                entity.HasMany(c => c.Sales)
                    .WithOne(s => s.Product)
                    .HasForeignKey(s => s.ProductId);
            });
            
            builder.Entity<Store>(entity =>
            {
                entity.Property(p => p.Name).HasColumnType("nvarchar(80)");
                entity.HasMany(c => c.Sales)
                      .WithOne(s => s.Store)
                      .HasForeignKey(s => s.StoreId);
            });

            builder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Date)
                    .IsRequired(false)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
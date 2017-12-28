using BMS.Data.EntityConfig;
using BMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BMS.Data
{
    public class BmsDbContext : DbContext
    {
        public BmsDbContext()
        {
        }

        public BmsDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Inquire> Inquires { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectSupplier> ProjectSuppliers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<ToDo> ToDoS { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BankAccountConfig());
            builder.ApplyConfiguration(new ContactPersonConfig());
            builder.ApplyConfiguration(new ContractConfig());
            builder.ApplyConfiguration(new InquiryConfig());
            builder.ApplyConfiguration(new OfferConfig());
            builder.ApplyConfiguration(new ProjectConfig());
            builder.ApplyConfiguration(new ProjectSupplierConfig());
            builder.ApplyConfiguration(new ToDoConfig());
            builder.ApplyConfiguration(new TransactionConfig());
        }
    }
}
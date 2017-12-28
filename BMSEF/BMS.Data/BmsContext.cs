using System.Data.Entity;
using BMS.Models;

namespace BMS.Data
{
    public class BmsContext : DbContext
    {
        public BmsContext()
            : base("name=BmsContext")
        {
            
        }
        
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Contragent> Contragents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inquiry> Inquiries { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<InvoiceClient> InvoicesClient { get; set; }
        public virtual DbSet<InvoiceSupplier> InvoicesSupplier { get; set; }
        public virtual DbSet<ProjectSupplier> ProjectsSuppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //To be tested!!!
            builder.Entity<Bank>()
                .HasIndex(e => e.Name)
                .IsUnique();

            builder.Entity<Bank>()
                .HasIndex(e => e.BIC)
                .IsUnique();

            builder.Entity<Bank>().Property(e => e.Name).IsRequired();
            builder.Entity<Bank>().Property(e => e.BIC).IsRequired();
            builder.Entity<Bank>().Property(e => e.Address).IsRequired();

            //--------------------
            
            builder.Entity<BankAccount>()
                .HasIndex(e => e.AccountNumber)
                .IsUnique();
            
            builder.Entity<BankAccount>()
                .HasRequired(e => e.Bank)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(e => e.BankId)
                .WillCascadeOnDelete(false);

            builder.Entity<BankAccount>()
                .HasRequired(e => e.Contragent)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(e => e.ContragentId)
                .WillCascadeOnDelete(false);
            
            //-------------------
            
            builder.Entity<Contragent>()
                .HasIndex(e => e.Name)
                .IsUnique();

            builder.Entity<Contragent>()
                .HasIndex(e => e.VatNumber)
                .IsUnique();
            
            builder.Entity<Contragent>()
                .HasIndex(e => e.PersonForContact)
                .IsUnique();
            
            //------------------

            builder.Entity<Employee>()
                .Property(e => e.Username)
                .HasColumnType("varchar(50)");
            
            builder.Entity<Employee>()
                .Property(e => e.Password)
                .HasColumnType("varchar(50)");
            
            //------------------
            
            
        }
    }
}
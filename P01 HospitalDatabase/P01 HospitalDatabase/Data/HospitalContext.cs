using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        
        public HospitalContext()
        {
            
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
            
        }
        
        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> PatientMedicament  { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>()
                .HasMany(v => v.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);
            
            builder.Entity<Patient>()
                .HasMany(d => d.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);
            
            builder.Entity<Patient>(entity =>
            {
                entity.Property(p => p.FirstName).HasColumnType("nvarchar(50)");
                entity.Property(p => p.LastName).HasColumnType("nvarchar(50)");
                entity.Property(p => p.Address).HasColumnType("nvarchar(250)");
                entity.Property(p => p.Email).HasColumnType("varchar(80)");
            });

            builder.Entity<Visitation>(entity =>
            {
                entity.Property(v => v.Comments).HasColumnType("nvarchar(250)");
            });
            
            builder.Entity<Diagnose>(entity =>
            {
                entity.Property(d => d.Name).HasColumnType("nvarchar(50)");
                entity.Property(d => d.Comments).HasColumnType("nvarchar(250)");
            });
            
            builder.Entity<Medicament>(entity =>
            {
                entity.Property(m => m.Name).HasColumnType("nvarchar(50)");
            });
            
            builder.Entity<PatientMedicament>()
                .ToTable("PatientsMedicaments")
                .HasKey(pm => new {pm.PatientId, pm.MedicamentId });

            builder.Entity<Doctor>()
                .HasMany(v => v.Visitations) 
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);

            builder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);
                entity.Property(m => m.Name).HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(m => m.Specialty).HasColumnType("nvarchar(100)").IsRequired();
            });
            builder.Entity<Visitation>(entity =>
            {
                entity.Property(d => d.DoctorId).IsRequired(false); 
            });
            
        }
    }
}
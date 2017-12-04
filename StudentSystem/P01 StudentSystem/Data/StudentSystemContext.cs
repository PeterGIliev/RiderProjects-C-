using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }
        
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
            
        }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=StudentSystem ;User ID=sa;Password=Peter@76545759");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Students --------------
            
            builder.Entity<Student>()
                .HasMany(s => s.CourseEnrollments)
                .WithOne(cs => cs.Student)
                .HasForeignKey(cs => cs.StudentId);

            builder.Entity<Student>()
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(hs => hs.Student)
                .HasForeignKey(hs => hs.StudentId);

            builder.Entity<Student>(entity =>
            {
                entity.Property(p => p.Name).HasColumnType("nvarchar(100)");
                entity.Property(p => p.PhoneNumber).HasColumnType("nvarchar(10)").IsRequired(false);
                //entity.Property(p => p.Birthday).IsRequired(false);
            });

            //Courses --------------
            
            builder.Entity<Course>()
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(cs => cs.CourseId);
            
            builder.Entity<Course>()
                .HasMany(sc => sc.StudentsEnrolled)
                .WithOne(r => r.Course)
                .HasForeignKey(cs => cs.CourseId);
            
            builder.Entity<Course>()
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(hs => hs.Course)
                .HasForeignKey(hs => hs.CourseId);
            
            builder.Entity<Course>(entity =>
            {
                entity.Property(p => p.Name).HasColumnType("nvarchar(80)");
                entity.Property(p => p.Description).HasColumnType("nvarchar(MAX)") .IsRequired(false);
            });
            
            //Resources --------------

            builder.Entity<Resource>(entity =>
            {
                entity.Property(p => p.Name).HasColumnType("nvarchar(50)");
                entity.Property(p => p.Url).HasColumnType("varchar(MAX)");
            });
            
            //Homework --------------

            builder.Entity<Homework>()
                .ToTable("HomeworkSubmissions");
            
            builder.Entity<Homework>(entity =>
            {
                entity.Property(p => p.Content).HasColumnType("varchar(MAX)");
            });
            
            //StudentCourses --------------
            
            builder.Entity<StudentCourse>()
                .ToTable("StudentsCourses")
                .HasKey(sc => new {sc.StudentId, sc.CourseId });
        }
    }
}
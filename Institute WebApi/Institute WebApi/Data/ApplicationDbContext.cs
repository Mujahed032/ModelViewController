using Institute_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Institute_WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<CourseFaculty> CourseFaculties { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentBatch> StudentBatches { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseFaculty>()
                .HasKey(cf => new { cf.CourseId, cf.FacultyId });

            modelBuilder.Entity<CourseFaculty>()
                .HasOne(cf => cf.Course)
                .WithMany(c => c.CourseFaculties)
                .HasForeignKey(cf => cf.CourseId);

            modelBuilder.Entity<CourseFaculty>()
                .HasOne(cf => cf.Faculty)
                .WithMany(f => f.CourseFaculties)
                .HasForeignKey(cf => cf.FacultyId);

            modelBuilder.Entity<StudentBatch>()
                .HasKey(sb => new { sb.BatchId, sb.StudentId });

            modelBuilder.Entity<StudentBatch>()
                .HasOne(sb => sb.Batch)
                .WithMany(b => b.StudentBatches)
                .HasForeignKey(sb => sb.BatchId);

            modelBuilder.Entity<StudentBatch>()
                .HasOne(sb => sb.Student)
                .WithMany(s => s.StudentBatches)
                .HasForeignKey(sb => sb.StudentId);

            modelBuilder.Entity<Payment>()
                .HasKey(p => new { p.PaymentDate, p.StudentId });

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId);
        }


    }
}

using Microsoft.EntityFrameworkCore;
using Student_Form.Models;

namespace Student_Form.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    

    public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.CurrentAddress)
                .WithMany()
                .HasForeignKey(s => s.CurrentAddress) // Use CurrentAddressId as the foreign key property
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.PermanentAddress)
                .WithMany()
                .HasForeignKey(s => s.PermanentAddress) // Use PermanentAddressId as the foreign key property
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

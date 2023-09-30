using Microsoft.EntityFrameworkCore;
using Student_Form.Models;

namespace Student_Form.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Student> students { get; set; }

        public DbSet<Address> addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.CurrentAddress)
                .WithMany()
                .HasForeignKey(s => s.AddressId) // Assuming you have a CurrentAddressId property in the Student class
                .OnDelete(DeleteBehavior.Restrict); // You can configure the delete behavior as needed

            modelBuilder.Entity<Student>()
                .HasOne(s => s.PermanentAddress)
                .WithMany()
                .HasForeignKey(s => s.AddressId) // Assuming you have a PermanentAddressId property in the Student class
                .OnDelete(DeleteBehavior.Restrict); // You can configure the delete behavior as needed
        }
    }
}

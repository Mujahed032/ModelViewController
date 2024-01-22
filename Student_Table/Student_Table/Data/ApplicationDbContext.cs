using Microsoft.EntityFrameworkCore;
using Student_Table.Models;

namespace Student_Table.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<SubjectMarks> SubjectMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationships between entities

            // Address - City relationship
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Address - State relationship
            modelBuilder.Entity<Address>()
                .HasOne(a => a.State)
                .WithMany()
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            // Address - Country relationship
            modelBuilder.Entity<Address>()
    .HasOne(a => a.Country)
    .WithMany()
    .HasForeignKey(a => a.CountryId)
    .OnDelete(DeleteBehavior.Restrict);


            // Configure the Student entity and its relationships

            modelBuilder.Entity<Student>()
                .HasOne(s => s.CurrentAddress)
                .WithMany()
                .HasForeignKey(s => s.CurrentAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.PermanentAddress)
                .WithMany()
                .HasForeignKey(s => s.PermanentAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // Add any other entity configurations here
        }




    }
}

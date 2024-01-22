using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Models;

namespace StudentRegistrationForm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Address> addresses { get; set; }

        public DbSet<Country> country { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> city { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
        .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            base.OnModelCreating(modelBuilder);

            // Seed data for the Country table
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = 1, Name = "India" },
                new Country { CountryID = 2, Name = "Japan" }
                // Add more countries as needed
            );

            // Seed data for the State table
            modelBuilder.Entity<State>().HasData(
                new State { StateID = 1, StateName = "Hyderabad", CountryID = 1 }, // Assign the appropriate CountryID
                new State { StateID = 2, StateName = "Mumbai", CountryID = 1 }
                // Add more states as needed
            ); 

            // Seed data for the City table
            modelBuilder.Entity<City>().HasData(
                new City { CityID = 1, CityName = "Tokyo", StateID = 1 }, // Assign the appropriate StateID
                new City { CityID = 2, CityName = "Japanese", StateID = 1 }
                // Add more cities as needed
            );
        }

    }

}

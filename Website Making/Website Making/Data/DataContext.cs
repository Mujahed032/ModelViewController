using Microsoft.EntityFrameworkCore;
using Website_Making.Models;

namespace Website_Making.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Location> Locations { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Location)
                .WithOne(l => l.Profile)
                .HasForeignKey<Profile>(p => p.LocationId);

            // Configure many-to-many relationships
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Photos)
                .WithMany(p => p.Profiles)
                .UsingEntity(j => j.ToTable("ProfilePhotos"));

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Interests)
                .WithMany(i => i.Profiles)
                .UsingEntity(j => j.ToTable("ProfileInterests"));

           
        }
    }
}

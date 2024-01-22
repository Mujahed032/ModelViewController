using Humsafar_Mubarak.Models;
using Microsoft.EntityFrameworkCore;

namespace Humsafar_Mubarak.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<PersonDetails> PersonDetails { get; set; }
        
        public DbSet<SalaryDetails> SalaryDetails { get; set; }
        public DbSet<User> Users { get; set; }
        

      
        
    }
}

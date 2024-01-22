using Microsoft.EntityFrameworkCore;
using PhoneTestingApi.Models;

namespace PhoneTestingApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Phone> phones { get; set; }

        public DbSet<Category> categories { get; set; }
    }
}

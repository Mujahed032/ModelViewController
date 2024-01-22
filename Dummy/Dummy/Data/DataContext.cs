using Dummy.Models;
using Microsoft.EntityFrameworkCore;

namespace Dummy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}

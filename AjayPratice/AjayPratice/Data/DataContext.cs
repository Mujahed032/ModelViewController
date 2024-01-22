using AjayPratice.Models;
using Microsoft.EntityFrameworkCore;

namespace AjayPratice.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}

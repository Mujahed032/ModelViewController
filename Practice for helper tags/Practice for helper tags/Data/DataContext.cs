using Microsoft.EntityFrameworkCore;
using Practice_for_helper_tags.Models;

namespace Practice_for_helper_tags.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}

using Employees_Mujahed.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees_Mujahed.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        public DbSet<EmployeesMujahed> employeeMujaheds { get; set; }
        
    }
}

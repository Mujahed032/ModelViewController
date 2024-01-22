using EmployeeRegistrationWithLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationWithLogin.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EmployeeMujahed> employeeMujaheds { get; set; }
    }
}

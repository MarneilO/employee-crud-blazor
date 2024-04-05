using EmployeeWebServer.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebServer.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }  
    }
}

using Microsoft.EntityFrameworkCore;

namespace Core.Web.Data
{
    //EmployeeDbContext is a medium to communitate with database
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

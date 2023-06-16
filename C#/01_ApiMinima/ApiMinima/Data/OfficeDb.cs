using ApiMinima.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinima.Data
{
    public class OfficeDb : DbContext
    {
        public OfficeDb(DbContextOptions<OfficeDb> options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
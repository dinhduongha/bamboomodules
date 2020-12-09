using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Employee.EntityFrameworkCore
{
    public class EmployeeHttpApiHostMigrationsDbContext : AbpDbContext<EmployeeHttpApiHostMigrationsDbContext>
    {
        public EmployeeHttpApiHostMigrationsDbContext(DbContextOptions<EmployeeHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureEmployee();
        }
    }
}

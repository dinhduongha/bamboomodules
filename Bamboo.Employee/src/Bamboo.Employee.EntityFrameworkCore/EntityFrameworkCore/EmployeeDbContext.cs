using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Employee.EntityFrameworkCore
{
    [ConnectionStringName(EmployeeDbProperties.ConnectionStringName)]
    public class EmployeeDbContext : AbpDbContext<EmployeeDbContext>, IEmployeeDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureEmployee();
        }
    }
}
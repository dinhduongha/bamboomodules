using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Sales.EntityFrameworkCore
{
    public class SalesHttpApiHostMigrationsDbContext : AbpDbContext<SalesHttpApiHostMigrationsDbContext>
    {
        public SalesHttpApiHostMigrationsDbContext(DbContextOptions<SalesHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSales();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.CRM.EntityFrameworkCore
{
    public class CRMHttpApiHostMigrationsDbContext : AbpDbContext<CRMHttpApiHostMigrationsDbContext>
    {
        public CRMHttpApiHostMigrationsDbContext(DbContextOptions<CRMHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCRM();
        }
    }
}

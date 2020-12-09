using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Base.EntityFrameworkCore
{
    public class BaseHttpApiHostMigrationsDbContext : AbpDbContext<BaseHttpApiHostMigrationsDbContext>
    {
        public BaseHttpApiHostMigrationsDbContext(DbContextOptions<BaseHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBase();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Stock.EntityFrameworkCore
{
    public class StockHttpApiHostMigrationsDbContext : AbpDbContext<StockHttpApiHostMigrationsDbContext>
    {
        public StockHttpApiHostMigrationsDbContext(DbContextOptions<StockHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureStock();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Stock.EntityFrameworkCore
{
    [ConnectionStringName(StockDbProperties.ConnectionStringName)]
    public class StockDbContext : AbpDbContext<StockDbContext>, IStockDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public StockDbContext(DbContextOptions<StockDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureStock();
        }
    }
}
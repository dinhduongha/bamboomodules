using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Stock.EntityFrameworkCore
{
    [ConnectionStringName(StockDbProperties.ConnectionStringName)]
    public interface IStockDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
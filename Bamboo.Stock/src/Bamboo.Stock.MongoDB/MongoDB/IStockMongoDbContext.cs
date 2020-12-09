using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Stock.MongoDB
{
    [ConnectionStringName(StockDbProperties.ConnectionStringName)]
    public interface IStockMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}

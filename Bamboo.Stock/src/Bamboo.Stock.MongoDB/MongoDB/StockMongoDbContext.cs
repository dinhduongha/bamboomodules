using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Stock.MongoDB
{
    [ConnectionStringName(StockDbProperties.ConnectionStringName)]
    public class StockMongoDbContext : AbpMongoDbContext, IStockMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureStock();
        }
    }
}
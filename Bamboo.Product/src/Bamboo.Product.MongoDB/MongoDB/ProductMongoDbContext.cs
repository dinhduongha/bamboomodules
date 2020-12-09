using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Product.MongoDB
{
    [ConnectionStringName(ProductDbProperties.ConnectionStringName)]
    public class ProductMongoDbContext : AbpMongoDbContext, IProductMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureProduct();
        }
    }
}
using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.Stock.MongoDB
{
    public class StockMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public StockMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.Sales.MongoDB
{
    public class SalesMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public SalesMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
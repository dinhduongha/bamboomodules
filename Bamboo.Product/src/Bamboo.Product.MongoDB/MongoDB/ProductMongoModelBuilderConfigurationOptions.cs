using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.Product.MongoDB
{
    public class ProductMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public ProductMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
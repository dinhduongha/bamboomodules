using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.Product.MongoDB
{
    public static class ProductMongoDbContextExtensions
    {
        public static void ConfigureProduct(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ProductMongoModelBuilderConfigurationOptions(
                ProductDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
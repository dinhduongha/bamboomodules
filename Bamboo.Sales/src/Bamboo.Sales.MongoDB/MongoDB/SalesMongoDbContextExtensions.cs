using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.Sales.MongoDB
{
    public static class SalesMongoDbContextExtensions
    {
        public static void ConfigureSales(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SalesMongoModelBuilderConfigurationOptions(
                SalesDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
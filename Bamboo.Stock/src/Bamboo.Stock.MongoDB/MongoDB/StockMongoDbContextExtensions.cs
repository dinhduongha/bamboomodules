using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.Stock.MongoDB
{
    public static class StockMongoDbContextExtensions
    {
        public static void ConfigureStock(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new StockMongoModelBuilderConfigurationOptions(
                StockDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
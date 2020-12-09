using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.CRM.MongoDB
{
    public static class CRMMongoDbContextExtensions
    {
        public static void ConfigureCRM(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CRMMongoModelBuilderConfigurationOptions(
                CRMDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
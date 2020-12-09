using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.Account.MongoDB
{
    public static class AccountMongoDbContextExtensions
    {
        public static void ConfigureAccount(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AccountMongoModelBuilderConfigurationOptions(
                AccountDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
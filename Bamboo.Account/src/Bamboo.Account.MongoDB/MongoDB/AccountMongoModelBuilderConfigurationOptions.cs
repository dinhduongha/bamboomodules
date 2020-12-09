using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.Account.MongoDB
{
    public class AccountMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AccountMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.CRM.MongoDB
{
    public class CRMMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public CRMMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
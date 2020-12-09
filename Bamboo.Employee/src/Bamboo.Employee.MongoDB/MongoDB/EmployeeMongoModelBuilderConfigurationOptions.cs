using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.Employee.MongoDB
{
    public class EmployeeMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public EmployeeMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
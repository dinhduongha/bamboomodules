using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bamboo.CRM.EntityFrameworkCore
{
    public class CRMModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CRMModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bamboo.Employee.EntityFrameworkCore
{
    public class EmployeeModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public EmployeeModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
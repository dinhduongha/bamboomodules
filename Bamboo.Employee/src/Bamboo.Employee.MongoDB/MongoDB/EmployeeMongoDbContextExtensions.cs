using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.Employee.MongoDB
{
    public static class EmployeeMongoDbContextExtensions
    {
        public static void ConfigureEmployee(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new EmployeeMongoModelBuilderConfigurationOptions(
                EmployeeDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
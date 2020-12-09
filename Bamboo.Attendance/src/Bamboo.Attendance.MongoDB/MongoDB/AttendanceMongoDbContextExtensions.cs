using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Bamboo.Attendance.MongoDB
{
    public static class AttendanceMongoDbContextExtensions
    {
        public static void ConfigureAttendance(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AttendanceMongoModelBuilderConfigurationOptions(
                AttendanceDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
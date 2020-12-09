using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bamboo.Attendance.EntityFrameworkCore
{
    public class AttendanceModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AttendanceModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
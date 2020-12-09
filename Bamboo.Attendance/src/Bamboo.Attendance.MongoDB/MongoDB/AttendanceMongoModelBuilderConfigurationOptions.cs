using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Bamboo.Attendance.MongoDB
{
    public class AttendanceMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AttendanceMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
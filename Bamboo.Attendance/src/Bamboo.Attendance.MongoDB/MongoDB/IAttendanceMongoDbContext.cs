using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Bamboo.Attendance.MongoDB
{
    [ConnectionStringName(AttendanceDbProperties.ConnectionStringName)]
    public interface IAttendanceMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}

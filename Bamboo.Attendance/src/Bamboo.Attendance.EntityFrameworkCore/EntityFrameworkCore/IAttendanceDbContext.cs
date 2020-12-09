using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Attendance.EntityFrameworkCore
{
    [ConnectionStringName(AttendanceDbProperties.ConnectionStringName)]
    public interface IAttendanceDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
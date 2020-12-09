using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Attendance.EntityFrameworkCore
{
    [ConnectionStringName(AttendanceDbProperties.ConnectionStringName)]
    public class AttendanceDbContext : AbpDbContext<AttendanceDbContext>, IAttendanceDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAttendance();
        }
    }
}
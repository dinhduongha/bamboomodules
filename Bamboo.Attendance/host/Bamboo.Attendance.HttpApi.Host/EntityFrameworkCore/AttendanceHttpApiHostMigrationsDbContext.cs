using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bamboo.Attendance.EntityFrameworkCore
{
    public class AttendanceHttpApiHostMigrationsDbContext : AbpDbContext<AttendanceHttpApiHostMigrationsDbContext>
    {
        public AttendanceHttpApiHostMigrationsDbContext(DbContextOptions<AttendanceHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAttendance();
        }
    }
}

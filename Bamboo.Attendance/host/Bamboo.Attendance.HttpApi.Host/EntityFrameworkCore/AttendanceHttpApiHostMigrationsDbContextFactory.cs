using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Attendance.EntityFrameworkCore
{
    public class AttendanceHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AttendanceHttpApiHostMigrationsDbContext>
    {
        public AttendanceHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AttendanceHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Attendance"));

            return new AttendanceHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}

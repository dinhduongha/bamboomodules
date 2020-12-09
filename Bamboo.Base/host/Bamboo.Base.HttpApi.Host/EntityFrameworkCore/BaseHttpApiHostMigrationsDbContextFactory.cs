using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Base.EntityFrameworkCore
{
    public class BaseHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BaseHttpApiHostMigrationsDbContext>
    {
        public BaseHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BaseHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Base"));

            return new BaseHttpApiHostMigrationsDbContext(builder.Options);
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

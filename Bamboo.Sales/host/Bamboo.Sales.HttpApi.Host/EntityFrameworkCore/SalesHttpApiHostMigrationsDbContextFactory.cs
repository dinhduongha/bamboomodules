using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Sales.EntityFrameworkCore
{
    public class SalesHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SalesHttpApiHostMigrationsDbContext>
    {
        public SalesHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SalesHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Sales"));

            return new SalesHttpApiHostMigrationsDbContext(builder.Options);
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

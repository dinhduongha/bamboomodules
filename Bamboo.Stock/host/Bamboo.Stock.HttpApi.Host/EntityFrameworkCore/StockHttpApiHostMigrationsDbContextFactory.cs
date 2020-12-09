using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Stock.EntityFrameworkCore
{
    public class StockHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<StockHttpApiHostMigrationsDbContext>
    {
        public StockHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<StockHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Stock"));

            return new StockHttpApiHostMigrationsDbContext(builder.Options);
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

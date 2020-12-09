using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Product.EntityFrameworkCore
{
    public class ProductHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProductHttpApiHostMigrationsDbContext>
    {
        public ProductHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ProductHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Product"));

            return new ProductHttpApiHostMigrationsDbContext(builder.Options);
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

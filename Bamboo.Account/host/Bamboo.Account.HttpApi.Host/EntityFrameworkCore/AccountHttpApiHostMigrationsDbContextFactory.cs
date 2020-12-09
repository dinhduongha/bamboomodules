using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Account.EntityFrameworkCore
{
    public class AccountHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AccountHttpApiHostMigrationsDbContext>
    {
        public AccountHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AccountHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Account"));

            return new AccountHttpApiHostMigrationsDbContext(builder.Options);
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

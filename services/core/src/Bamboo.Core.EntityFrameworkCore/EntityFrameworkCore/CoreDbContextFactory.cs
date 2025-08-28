using System;
using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Core.EntityFrameworkCore
{
    
    /* This class is needed for EF Core console commands
    * (like Add-Migration and Update-Database commands) */
    public class CoreDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var configuration = new ConfigurationBuilder()
                //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Bamboo.HttpApi.Host"))
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../host/Bamboo.Core.HttpApi.Host"))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true) // nếu có
                .AddJsonFile("appsettings.secrets.json", optional: true) // nếu có
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(CoreDbProperties.ConnectionStringName);

            var builder = new DbContextOptionsBuilder<CoreDbContext>()
                .UseNpgsql(connectionString);

            return new CoreDbContext(builder.Options);
        }
    }
}

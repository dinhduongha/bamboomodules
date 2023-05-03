﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bamboo.Core.EntityFrameworkCore;

public class CoreHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CoreHttpApiHostMigrationsDbContext>
{
    public CoreHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CoreHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Core"));

        return new CoreHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

using Bamboo.Core.EntityFrameworkCore;

public class DbMigrationService(
    ILogger<DbMigrationService> logger,
    ITenantRepository tenantRepository,
    IDataSeeder dataSeeder,
    ICurrentTenant currentTenant,
    IUnitOfWorkManager unitOfWorkManager
) : ITransientDependency
{
    private readonly ICurrentTenant _currentTenant = currentTenant;
    private readonly IDataSeeder _dataSeeder = dataSeeder;
    private readonly ILogger<DbMigrationService> _logger = logger;
    private readonly ITenantRepository _tenantRepository = tenantRepository;
    private readonly IUnitOfWorkManager _unitOfWorkManager = unitOfWorkManager;

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await CreateDatabasesAsync(cancellationToken);

        _logger.LogInformation("Starting Migrations ...");
        await MigrateHostAsync(cancellationToken);
        await MigrateTenantsAsync(cancellationToken);
        _logger.LogInformation("Completed Migrations.");
    }

    private async Task CreateDatabasesAsync(CancellationToken cancellationToken)
    {
        using var uow = _unitOfWorkManager.Begin(true);

        //await EnsureDatabaseAsync<AdminDbContext>(cancellationToken);
        await EnsureDatabaseAsync<CoreDbContext>(cancellationToken);

        await uow.CompleteAsync(cancellationToken);
    }

    private async Task MigrateHostAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Migrating Host side ...");
        await MigrateDatabasesAsync(null, cancellationToken);
        await SeedDataAsync(null);
        _logger.LogInformation("Host side migration completed.");
    }

    private async Task MigrateTenantsAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Migrating tenants ...");

        var tenants = await _tenantRepository.GetListAsync(
            includeDetails: true,
            cancellationToken: cancellationToken
        );
        var migratedDatabaseSchemas = new HashSet<string>();

        foreach (var tenant in tenants)
        {
            using (_currentTenant.Change(tenant.Id))
            {
                // Database schema migration
                var connectionString = tenant.FindDefaultConnectionString();
                if (
                    !connectionString.IsNullOrWhiteSpace()
                    && //tenant has a separate database
                    !migratedDatabaseSchemas.Contains(connectionString)
                ) //the database was not migrated yet
                {
                    _logger.LogInformation(
                        "Migrating Tenant: {Name} ({TenantId})",
                        tenant.Name,
                        tenant.Id
                    );

                    await MigrateDatabasesAsync(tenant, cancellationToken);
                    migratedDatabaseSchemas.AddIfNotContains(connectionString);
                }

                //Seed data
                await SeedDataAsync(tenant);
            }
        }

        _logger.LogInformation("Tenant migrations are complete.");
    }

    private async Task EnsureDatabaseAsync<TDbContext>(CancellationToken cancellationToken)
        where TDbContext : DbContext, IEfCoreDbContext
    {
        var dbContext = await _unitOfWorkManager
            .Current!.ServiceProvider.GetRequiredService<IDbContextProvider<TDbContext>>()
            .GetDbContextAsync();

        var strategy = dbContext.Database.CreateExecutionStrategy();

        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

        await strategy.ExecuteAsync(async () =>
        {
            // Create the database if it does not exist.
            // Do this first so there is then a database to start a transaction against.
            if (!await dbCreator.ExistsAsync(cancellationToken))
            {
                await dbCreator.CreateAsync(cancellationToken);
            }
        });
    }

    private async Task MigrateDatabasesAsync(Tenant? tenant, CancellationToken cancellationToken)
    {
        using var uow = _unitOfWorkManager.Begin(true);

        if (tenant is null)
        {
            /* SaaS schema should only be available in the host side */
            // await MigrateDatabaseAsync<SaaSDbContext>(cancellationToken);
        }
        // await MigrateDatabaseAsync<AdminDbContext>(cancellationToken);
        await MigrateDatabaseAsync<CoreDbContext>(cancellationToken);
        await uow.CompleteAsync(cancellationToken);
    }

    private async Task MigrateDatabaseAsync<TDbContext>(CancellationToken cancellationToken)
        where TDbContext : DbContext, IEfCoreDbContext
    {
        var name = typeof(TDbContext).Name.RemovePostFix("DbContext");

        _logger.LogInformation("Migrating {Name} database ...", name);

        var dbContext = await _unitOfWorkManager
            .Current!.ServiceProvider.GetRequiredService<IDbContextProvider<TDbContext>>()
            .GetDbContextAsync();

        await ApplyMigrationAsync(dbContext, cancellationToken);

        _logger.LogInformation("Completed migrating ({Name}).", name);
    }

    private static async Task ApplyMigrationAsync<TDbContext>(
        TDbContext dbContext,
        CancellationToken cancellationToken
    )
        where TDbContext : DbContext, IEfCoreDbContext
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await dbContext.Database.MigrateAsync(cancellationToken);
        });
    }

    private async Task SeedDataAsync(Tenant? tenant)
    {
        if (tenant is null)
        {
            _logger.LogInformation("Seeding host data ...");
        }
        else
        {
            _logger.LogInformation("Seeding tenant data: {Name} ({Id})", tenant.Name, tenant.Id);
        }

        // await _dataSeeder.SeedAsync(
        //     new DataSeedContext(tenant?.Id)
        //         .WithProperty(
        //             IdentityDataSeedContributor.AdminEmailPropertyName,
        //             IdentityDataSeedContributor.AdminEmailDefaultValue
        //         )
        //         .WithProperty(
        //             IdentityDataSeedContributor.AdminPasswordPropertyName,
        //             IdentityDataSeedContributor.AdminPasswordDefaultValue
        //         )
        // );
    }
}

#if OLD_VERSION

public class DbMigrationService : ITransientDependency
{
    public ILogger<DbMigrationService> Logger { get; set; }

    private readonly IDataSeeder _dataSeeder;
    private readonly IEnumerable<IDbSchemaMigrator> _dbSchemaMigrators;
    private readonly ITenantRepository _tenantRepository;
    private readonly ICurrentTenant _currentTenant;

    public DbMigrationService(
        IDataSeeder dataSeeder,
        IEnumerable<IDbSchemaMigrator> dbSchemaMigrators,
        ITenantRepository tenantRepository,
        ICurrentTenant currentTenant)
    {
        _dataSeeder = dataSeeder;
        _dbSchemaMigrators = dbSchemaMigrators;
        _tenantRepository = tenantRepository;
        _currentTenant = currentTenant;

        Logger = NullLogger<DbMigrationService>.Instance;
    }

    public async Task MigrateAsync()
    {
        var initialMigrationAdded = AddInitialMigrationIfNotExist();

        if (initialMigrationAdded)
        {
            return;
        }

        Logger.LogInformation("Started database migrations...");

        await MigrateDatabaseSchemaAsync();
        await SeedDataAsync();

        Logger.LogInformation($"Successfully completed host database migrations.");

        var tenants = await _tenantRepository.GetListAsync(includeDetails: true);

        var migratedDatabaseSchemas = new HashSet<string>();
        foreach (var tenant in tenants)
        {
            using (_currentTenant.Change(tenant.Id))
            {
                if (tenant.ConnectionStrings.Any())
                {
                    var tenantConnectionStrings = tenant.ConnectionStrings
                        .Select(x => x.Value)
                        .ToList();

                    if (!migratedDatabaseSchemas.IsSupersetOf(tenantConnectionStrings))
                    {
                        await MigrateDatabaseSchemaAsync(tenant);

                        migratedDatabaseSchemas.AddIfNotContains(tenantConnectionStrings);
                    }
                }

                await SeedDataAsync(tenant);
            }

            Logger.LogInformation($"Successfully completed {tenant.Name} tenant database migrations.");
        }

        Logger.LogInformation("Successfully completed all database migrations.");
        Logger.LogInformation("You can safely end this process...");
    }

    private async Task MigrateDatabaseSchemaAsync(Tenant? tenant = null)
    {
        Logger.LogInformation(
            $"Migrating schema for {(tenant == null ? "host" : tenant.Name + " tenant")} database...");

        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async Task SeedDataAsync(Tenant? tenant = null)
    {
        Logger.LogInformation($"Executing {(tenant == null ? "host" : tenant.Name + " tenant")} database seed...");
        /*
        // For Admin module 
        await _dataSeeder.SeedAsync(new DataSeedContext(tenant?.Id)
            .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, IdentityDataSeedContributor.AdminEmailDefaultValue)
            .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, IdentityDataSeedContributor.AdminPasswordDefaultValue)
        );
        */
    }

    private bool AddInitialMigrationIfNotExist()
    {
        try
        {
            if (!DbMigrationsProjectExists())
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

        try
        {
            if (!MigrationsFolderExists())
            {
                AddInitialMigration();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Logger.LogWarning("Couldn't determinate if any migrations exist : " + e.Message);
            return false;
        }
    }

    private bool DbMigrationsProjectExists()
    {
        var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();

        return dbMigrationsProjectFolder != null;
    }

    private bool MigrationsFolderExists()
    {
        var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();
        return dbMigrationsProjectFolder != null && Directory.Exists(Path.Combine(dbMigrationsProjectFolder, "Migrations"));
    }

    private void AddInitialMigration()
    {
        Logger.LogInformation("Creating initial migration...");

        string argumentPrefix;
        string fileName;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            argumentPrefix = "-c";
            fileName = "/bin/bash";
        }
        else
        {
            argumentPrefix = "/C";
            fileName = "cmd.exe";
        }

        var procStartInfo = new ProcessStartInfo(fileName,
            $"{argumentPrefix} \"abp create-migration-and-run-migrator \"{GetEntityFrameworkCoreProjectFolderPath()}\"\""
        );

        try
        {
            Process.Start(procStartInfo);
        }
        catch (Exception)
        {
            throw new Exception("Couldn't run ABP CLI...");
        }
    }

    private string? GetEntityFrameworkCoreProjectFolderPath()
    {
        var slnDirectoryPath = GetSolutionDirectoryPath();

        if (slnDirectoryPath == null)
        {
            throw new Exception("Solution folder not found!");
        }

        var srcDirectoryPath = Path.Combine(slnDirectoryPath, "src");

        return Directory.GetDirectories(srcDirectoryPath)
            .FirstOrDefault(d => d.EndsWith(".EntityFrameworkCore"));
    }

    private string? GetSolutionDirectoryPath()
    {
        var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (currentDirectory != null && Directory.GetParent(currentDirectory.FullName) != null)
        {
            currentDirectory = Directory.GetParent(currentDirectory.FullName);

            if (currentDirectory != null && Directory.GetFiles(currentDirectory.FullName).FirstOrDefault(f => f.EndsWith(".sln")) != null)
            {
                return currentDirectory.FullName;
            }
        }

        return null;
    }
}
#endif
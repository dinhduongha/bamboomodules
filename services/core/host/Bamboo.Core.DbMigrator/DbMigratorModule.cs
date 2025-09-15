using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Tokens;

using Bamboo.Core.EntityFrameworkCore;
using Bamboo.Core;

/*
User must change "Administration" to module's name
*/
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(CoreEntityFrameworkCoreModule),
    typeof(CoreApplicationContractsModule)
    )]

public class DbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });
        // context.Services.AddAbpDbContext<CoreDbContext>(options =>
        // {
        //     options.AddDefaultRepositories(includeAllEntities: true);
        // });
        // context.Services.AddDbContext<CoreDbContext>(options =>
        // {
        //     options.UseNpgsql(configuration.GetConnectionString("Core"),
        //         npgsqlOptions => npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "public"));
        // });
        Configure<TokenCleanupOptions>(options => options.IsCleanupEnabled = false);
        //context.Services.AddTransient<MigrationService>();
        context.Services.AddTransient<DbMigrationService>();
    }
}

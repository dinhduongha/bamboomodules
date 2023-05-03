using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bamboo.Admin.Data;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Admin.EntityFrameworkCore;

public class EntityFrameworkCoreAdminDbSchemaMigrator
    : IAdminDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAdminDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AdminDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AdminDbContext>()
            .Database
            .MigrateAsync();
    }
}

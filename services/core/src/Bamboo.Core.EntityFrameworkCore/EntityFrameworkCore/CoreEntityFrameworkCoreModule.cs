using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Bamboo.Shared.EfCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Bamboo.Core.EntityFrameworkCore;

[DependsOn(
    typeof(CoreDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpSharedEfCoreModule)
)]
public class CoreEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var connectionString = configuration.GetConnectionString(CoreDbProperties.ConnectionStringName);

        context.Services.AddAbpDbContext<CoreDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        context.Services.AddTransient<IJunctionTableMetadataProvider, JunctionTableMetadataProvider>();
    }
}

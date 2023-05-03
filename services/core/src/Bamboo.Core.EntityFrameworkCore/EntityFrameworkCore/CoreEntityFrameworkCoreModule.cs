using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Bamboo.Shared.EfCore;

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
        context.Services.AddAbpDbContext<CoreDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}

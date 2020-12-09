using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Domain;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace Bamboo.Base
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(BaseDomainSharedModule)
    )]
    public class BaseDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
#if HAS_DB_POSTGRESQL
            Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString;
            });
#endif
            //context.Services.AddTransient<IGuidGenerator, MySequentialGuidGenerator>();
            context.Services.Replace(ServiceDescriptor.Transient<IGuidGenerator, MySequentialGuidGenerator>());
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace Bamboo.Shared.EfCore;
public class AbpSharedEfCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpSequentialGuidGeneratorOptions>(options =>
        {
            options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString;
        });
        context.Services.Replace(ServiceDescriptor.Transient<IGuidGenerator, MySequentialGuidGenerator>());
    }
}

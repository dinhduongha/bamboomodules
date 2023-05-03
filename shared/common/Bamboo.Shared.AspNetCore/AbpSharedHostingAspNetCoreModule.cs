using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

[DependsOn(
    typeof(AbpSharedHostingModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class AbpSharedHostingAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
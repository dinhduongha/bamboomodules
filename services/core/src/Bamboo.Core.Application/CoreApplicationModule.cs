using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Bamboo.Core.Application;
using Bamboo.Core.Application.Contracts.Interfaces;

namespace Bamboo.Core;

[DependsOn(
    typeof(CoreDomainModule),
    typeof(CoreApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class CoreApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CoreApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CoreApplicationModule>(validate: true);
        });

        context.Services.AddSingleton<IModelTypeRegistry>(provider =>
        {
            var registry = new ModelTypeRegistry();
            registry.RegisterTypes(typeof(CoreDomainSharedModule).Assembly);
            registry.RegisterServiceTypes([typeof(CoreApplicationModule).Assembly]);
            return registry;
        });
        context.Services.AddTransient(typeof(IRepositoryService<>), typeof(RepositoryService<>));

        context.Services.AddTransient(typeof(IGenericApplicationService<>), typeof(GenericApplicationService<>));
        
    }
}

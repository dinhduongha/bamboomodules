using Microsoft.Extensions.DependencyInjection;
using Bamboo.Employee.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Employee.Blazor
{
    [DependsOn(
        typeof(EmployeeHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class EmployeeBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<EmployeeBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<EmployeeBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new EmployeeMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(EmployeeBlazorModule).Assembly);
            });
        }
    }
}
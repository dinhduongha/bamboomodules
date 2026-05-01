using Volo.Abp.AspNetCore.Components.Server.Theming.MudBlazor;
using Volo.Abp.Modularity;

namespace Bamboo.Core.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingMudBlazorModule),
    typeof(CoreBlazorModule)
    )]
public class CoreBlazorServerModule : AbpModule
{

}

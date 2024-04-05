using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Bamboo.Core.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CoreBlazorModule)
    )]
public class CoreBlazorServerModule : AbpModule
{

}

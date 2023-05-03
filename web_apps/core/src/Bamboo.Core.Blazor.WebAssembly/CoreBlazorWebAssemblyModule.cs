using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Bamboo.Core.Blazor.WebAssembly;

[DependsOn(
    typeof(CoreBlazorModule),
    typeof(CoreHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CoreBlazorWebAssemblyModule : AbpModule
{

}

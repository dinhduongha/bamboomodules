using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.MudBlazor;
using Volo.Abp.Modularity;

namespace Bamboo.Core.Blazor.WebAssembly;

[DependsOn(
    typeof(CoreBlazorModule),
    typeof(CoreHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingMudBlazorModule)
    )]
public class CoreBlazorWebAssemblyModule : AbpModule
{

}

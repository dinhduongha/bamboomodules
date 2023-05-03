using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Bamboo.Core.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Core";
}

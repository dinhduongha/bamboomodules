using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Bamboo.Blazor;

[Dependency(ReplaceServices = true)]
public class BambooBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bamboo";
}

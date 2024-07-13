using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Bamboo.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class BambooBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bamboo";
}

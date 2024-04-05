using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Web;

[Dependency(ReplaceServices = true)]
public class BambooBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bamboo";
}

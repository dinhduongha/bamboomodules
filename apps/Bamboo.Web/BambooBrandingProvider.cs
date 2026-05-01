using Microsoft.Extensions.Localization;
using Bamboo.Admin.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Web;

[Dependency(ReplaceServices = true)]
public class BambooBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AdminResource> _localizer;

    public BambooBrandingProvider(IStringLocalizer<AdminResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}

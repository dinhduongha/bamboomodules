using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Base
{
    [Dependency(ReplaceServices = true)]
    public class BaseBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Base";
    }
}

using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.CRM
{
    [Dependency(ReplaceServices = true)]
    public class CRMBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CRM";
    }
}

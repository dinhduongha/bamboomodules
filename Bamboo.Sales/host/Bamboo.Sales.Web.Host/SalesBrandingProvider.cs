using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Sales
{
    [Dependency(ReplaceServices = true)]
    public class SalesBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Sales";
    }
}

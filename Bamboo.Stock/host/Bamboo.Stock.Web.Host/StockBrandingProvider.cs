using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Stock
{
    [Dependency(ReplaceServices = true)]
    public class StockBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Stock";
    }
}

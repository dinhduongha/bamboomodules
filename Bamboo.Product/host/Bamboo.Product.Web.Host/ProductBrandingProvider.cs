using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Product
{
    [Dependency(ReplaceServices = true)]
    public class ProductBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Product";
    }
}

using Volo.Abp.Modularity;

namespace Bamboo.Product
{
    [DependsOn(
        typeof(ProductApplicationModule),
        typeof(ProductDomainTestModule)
        )]
    public class ProductApplicationTestModule : AbpModule
    {

    }
}

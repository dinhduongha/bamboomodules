using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Bamboo.App;

[DependsOn(typeof(AbpAutofacModule))]
public class AppModule : AbpModule
{
}

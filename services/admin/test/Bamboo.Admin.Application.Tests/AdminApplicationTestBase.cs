using Volo.Abp.Modularity;

namespace Bamboo.Admin;

public abstract class AdminApplicationTestBase<TStartupModule> : AdminTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

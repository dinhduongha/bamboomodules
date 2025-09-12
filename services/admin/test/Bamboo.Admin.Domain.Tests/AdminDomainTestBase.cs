using Volo.Abp.Modularity;

namespace Bamboo.Admin;

/* Inherit from this class for your domain layer tests. */
public abstract class AdminDomainTestBase<TStartupModule> : AdminTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

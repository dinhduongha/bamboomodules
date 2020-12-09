using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Account
{
    [Dependency(ReplaceServices = true)]
    public class AccountBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Account";
    }
}

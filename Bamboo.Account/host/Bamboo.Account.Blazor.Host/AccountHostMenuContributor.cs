using System.Threading.Tasks;
using Bamboo.Account.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Account.Blazor.Host
{
    public class AccountHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<AccountResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Account.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

using System.Threading.Tasks;
using Bamboo.CRM.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.CRM.Blazor.Host
{
    public class CRMHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<CRMResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "CRM.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

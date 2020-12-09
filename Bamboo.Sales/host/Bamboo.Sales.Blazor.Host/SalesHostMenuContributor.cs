using System.Threading.Tasks;
using Bamboo.Sales.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Sales.Blazor.Host
{
    public class SalesHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<SalesResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Sales.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

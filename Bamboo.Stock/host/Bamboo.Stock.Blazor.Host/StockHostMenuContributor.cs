using System.Threading.Tasks;
using Bamboo.Stock.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Stock.Blazor.Host
{
    public class StockHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<StockResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Stock.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

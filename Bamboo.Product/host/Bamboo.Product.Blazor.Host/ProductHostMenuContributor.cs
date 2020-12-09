using System.Threading.Tasks;
using Bamboo.Product.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Product.Blazor.Host
{
    public class ProductHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<ProductResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Product.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

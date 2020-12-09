using System.Threading.Tasks;
using Bamboo.Base.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Base.Blazor.Host
{
    public class BaseHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<BaseResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Base.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

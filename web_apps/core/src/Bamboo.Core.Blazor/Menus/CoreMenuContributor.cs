using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Core.Blazor.Menus;

public class CoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CoreMenus.Prefix, displayName: "Core", "/Core", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}

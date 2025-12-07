using System.Threading.Tasks;
using Bamboo.Admin.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Abp.LoginUi.Web.Menus;

public class AdminWebMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
        //else if (context.Menu.Name == "Manage")
        {
            await ConfigureAccountManagementMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AdminResource>();

        // Thêm mục "Members" vào menu chính, chỉ hiển thị khi ở trong một tenant
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Admin.Members",
                l["Members"],
                url: "/Members",
                icon: "fa fa-users",
                order: 1000
            )
        //{ RequireTenant = true } // Chỉ hiển thị khi có tenant
        );

        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        // Có thể thêm các mục vào menu dropdown của user ở đây nếu cần
        // var l = context.GetLocalizer<AdminResource>();
        // context.Menu.AddItem(new ApplicationMenuItem("Account.Workspaces", l["Workspaces"], "/Account/Workspaces", icon: "fa fa-briefcase", order: 100));
        return Task.CompletedTask;
    }

    private Task ConfigureAccountManagementMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AdminResource>();
        context.Menu.AddItem(new ApplicationMenuItem("Account.Workspaces", l["Workspaces"], "/Account/Workspaces", icon: "fa fa-briefcase", order: 100));
        return Task.CompletedTask;
    }
}

using System.Threading.Tasks;
using Bamboo.Abp.LoginUi.Web.Pages.Account.Components.Workspaces;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account.Web.ProfileManagement;

namespace Bamboo.Abp.LoginUi.Web.ProfileManagement;

public class MyWorkspacesPageContributor : IProfileManagementPageContributor
{
    public Task ConfigureAsync(ProfileManagementPageCreationContext context)
    {
        var l = context.ServiceProvider.GetRequiredService<Microsoft.Extensions.Localization.IStringLocalizer<Bamboo.Abp.LoginUi.Web.Localization.AbpLoginUiResource>>();
        context.Groups.Add(
            new ProfileManagementPageGroup(
                "Bamboo.Workspaces",
                l["Workspaces"],
                typeof(WorkspacesViewComponent)
            ));
        return Task.CompletedTask;
    }
}
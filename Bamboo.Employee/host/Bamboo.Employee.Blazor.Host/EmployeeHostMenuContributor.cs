using System.Threading.Tasks;
using Bamboo.Employee.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Employee.Blazor.Host
{
    public class EmployeeHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<EmployeeResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Employee.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

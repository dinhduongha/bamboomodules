using System.Threading.Tasks;
using Bamboo.Attendance.Localization;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Attendance.Blazor.Host
{
    public class AttendanceHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<AttendanceResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Attendance.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}

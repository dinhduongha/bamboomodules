using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Bamboo.Attendance.Pages
{
    public class IndexModel : AttendancePageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Bamboo.Employee.Pages
{
    public class IndexModel : EmployeePageModel
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
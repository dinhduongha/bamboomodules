using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Bamboo.CRM.Pages
{
    public class IndexModel : CRMPageModel
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
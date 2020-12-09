using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Bamboo.Account.Pages
{
    public class IndexModel : AccountPageModel
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
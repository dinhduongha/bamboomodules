using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Bamboo.Web.Pages;

public class IndexModel : BambooPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}

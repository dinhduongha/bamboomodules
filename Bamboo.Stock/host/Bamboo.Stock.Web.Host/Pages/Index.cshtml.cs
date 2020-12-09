using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Bamboo.Stock.Pages
{
    public class IndexModel : StockPageModel
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
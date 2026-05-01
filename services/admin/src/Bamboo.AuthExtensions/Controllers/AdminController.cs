using Bamboo.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.Admin.Controllers;

/* Inherit your controllers from this class.
 */
//[Area("admin")]
public abstract class AdminController : AbpControllerBase
{
    protected AdminController()
    {
        LocalizationResource = typeof(AdminResource);
    }
}

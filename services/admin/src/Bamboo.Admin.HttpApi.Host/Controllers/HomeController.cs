using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Admin.Controllers;

public class HomeController : AbpController
{
    public ActionResult Index()
    {
        return Redirect($"{Request.PathBase}/swagger");
        //return Redirect("~/swagger");
        //return Redirect("~/api/v1/core");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Admin.Controllers;

public class HomeController : AbpController
{
    private readonly IConfiguration configuration;

    public HomeController(IConfiguration config)
    {
        configuration = config;
    }
    public ActionResult Index()
    {
        if (configuration.GetValue<bool>("Swagger:IsEnabled", false))
        {
            return Redirect("~/swagger");
        }
        return Ok();
    }
}

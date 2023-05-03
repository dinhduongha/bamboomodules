using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

using Bamboo.AdminExtensions.Dtos;

namespace Bamboo.AdminExtensions.Controllers;

[Route("api/admin")]
[Produces("application/json")]
[Consumes("application/json")]
public class AdminResetPasswordController : AbpController
{
    protected AdminResetPasswordAppService _adminService;
    public AdminResetPasswordController(AdminResetPasswordAppService adminService)
    {
        _adminService = adminService;
    }
        
    [HttpPost]
    [Route("admin-reset-password")]    
    public async Task AdminResetPassword([FromBody] AdminResetPasswordDto input)
    {
        await _adminService.AdminResetPasswordAsync(input);
    }

}
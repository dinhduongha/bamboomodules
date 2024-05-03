using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.AspNetCore.Mvc;
using static Volo.Abp.Identity.IdentityPermissions;
using Bamboo.AdminExtensions.Dtos;

namespace Bamboo.AdminExtensions.Controllers;

[Route("api/admin")]
[Produces("application/json")]
[Consumes("application/json")]
[Authorize(Roles = "admin")]
public class HostAdminController : AbpController
{
    protected AdminResetPasswordAppService _adminResetPasswordService;
    public HostAdminController(AdminResetPasswordAppService adminResetPasswordService)
    {
        _adminResetPasswordService = adminResetPasswordService;
    }
        
    [HttpPost]
    [Route("admin-reset-password")]    
    public async Task AdminResetPassword([FromBody] AdminResetPasswordDto input)
    {
        await _adminResetPasswordService.AdminResetPasswordAsync(input);
    }

}
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.AdminExtensions.Controllers;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(AccountController), IncludeSelf = true)]
//[ExposeServices(typeof(AccountController), typeof(BambooAccountController))]
public class BambooAccountController : AccountController
{
    public BambooAccountController(
        IAccountAppService accountAppService)
        : base(accountAppService)
    {
    }

    public async override Task<IdentityUserDto> RegisterAsync(RegisterDto input)
    {
        // return await AccountAppService.RegisterAsync(input);
        await Task.CompletedTask;
        throw new UserFriendlyException("New user must login by Google/Facebook to register!");
    }

    public async override Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
    {
        await AccountAppService.SendPasswordResetCodeAsync(input);
    }

    public async override Task ResetPasswordAsync(ResetPasswordDto input)
    {
        await AccountAppService.ResetPasswordAsync(input);
    }

    

}
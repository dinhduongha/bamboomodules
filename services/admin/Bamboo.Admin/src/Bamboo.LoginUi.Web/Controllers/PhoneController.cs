using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc;

using Volo.Abp.Account;

namespace Bamboo.LoginUiWeb;

[Route("api/phone/")]
[Produces("application/json")]
public class PhoneController : AbpControllerBase
{

    private readonly PhoneService _phoneService;
    public PhoneController(PhoneService phoneService)
    {
        _phoneService = phoneService;
    }
    [HttpPost]
    [Route("admin-reset-password")]
    [Authorize]
    public async Task ResetPassword([FromBody] ResetPasswordDto input)
    {
        await _phoneService.ResetPasswordAsync(input);
    }

    /// <summary>
    /// Register user or reset password, use firebase or sms
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public async Task<string> Register([FromBody] ExternalRegisterOrUpdateDto account, string provider = "" )
    {
        var user = await _phoneService.Register(account, provider);
        await Task.CompletedTask;
        return user.PhoneNumber;
    }

    [HttpPost]
    [Route("change-password")]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public async Task<string> ChangePassword([FromBody] ExternalRegisterOrUpdateDto account, string provider = "")
    {
        var user = await _phoneService.ChangePassword(account, provider);
        await Task.CompletedTask;
        return user.PhoneNumber;
    }

    /// <summary>
    /// Get code, send code to user for SMS verification
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("smsToken")]
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public async Task<string> Token(string phone)
    {
        var token = await _phoneService.smsToken(phone);
        return phone;
    }
    
    /// <summary>
    /// Generate code, let user send the code to SMS Provider for verification. Sms provider must call webhook to own server
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    //[HttpGet]
    //[Route("smsTokenProviderCallback")]
    //[AllowAnonymous]
    //[IgnoreAntiforgeryToken]
    //public async Task<string> TokenReceive(string phone)
    //{
    //    if (!Regex.Match(phone, @"^([+]|[00])([0-9]){5,13}$").Success)
    //    {
    //        throw new Exception("Invalid phone number");
    //    }
    //    var code = await _phoneService.TokenReceived(phone);
    //    throw new UserFriendlyException("Not yet implement");
    //    return code;
    //}
}



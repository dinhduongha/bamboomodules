using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Linq;
using System.Net.Mail;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;

using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Account.Web;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

using Telegram.Bot.Extensions.LoginWidget;

namespace Bamboo.LoginUiWeb.Controllers;

[Route("api/telegram")]
public class TelegramLoginController : AbpControllerBase
{
    // https://stackoverflow.com/questions/68157777/implementing-telegram-loginwidget-with-signinmanager
    
    private readonly IConfiguration configuration;
    //private readonly SignInManager<ApplicationUser> _signInManager;
    //private readonly UserManager<ApplicationUser> _userManager;

    public IAccountAppService AccountAppService { get; set; }
    public SignInManager<IdentityUser> SignInManager { get; set; }
    public IdentityUserManager UserManager { get; set; }
    public IdentitySecurityLogManager IdentitySecurityLogManager { get; set; }
    public IOptions<IdentityOptions> IdentityOptions { get; set; }
    public IdentityDynamicClaimsPrincipalContributorCache IdentityDynamicClaimsPrincipalContributorCache { get; set; }

public TelegramLoginController(
        IConfiguration config,
        IAuthenticationSchemeProvider schemeProvider,
        IOptions<AbpAccountOptions> accountOptions,
        IOptions<IdentityOptions> identityOptions,
        IdentityDynamicClaimsPrincipalContributorCache cache
        )
    {
        configuration = config;
    }

    [HttpGet]
    [Route("callback")]
    public async Task<IActionResult> Tgcallback(
        string id,
        string first_name,
        string last_name,
        string username,
        string photo_url,
        string auth_date,
        string hash)
    {
        // attempt to authenticate the login
        var token = configuration["Telegram:BotToken"];
        var loginWidget = new LoginWidget(token);
        loginWidget.AllowedTimeOffset = 120;
        var auth = loginWidget.CheckAuthorization(new SortedDictionary<string, string>()
        {
            {"id",id},
            {"first_name", first_name},
            {"last_name", last_name},
            {"username", username},
            {"photo_url", photo_url},
            {"auth_date", auth_date},
            {"hash", hash}
        });

        // if the authorization was successful, create the user (if not exist) and sign in
        if (auth == Authorization.Valid)
        {
            var LoginProvider = "Telegram";
            var ProviderKey = id;
            var returnUrl = configuration["Telegram:ReturnUrl"];
            ExternalLoginInfo loginInfo = new ExternalLoginInfo(null, LoginProvider, ProviderKey, username);

            await IdentityOptions.SetAsync();

            var result = await SignInManager.ExternalLoginSignInAsync(
                LoginProvider,
                ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true
            );
            IdentityUser user;
            if (result.Succeeded)
            {
                user = await UserManager.FindByLoginAsync(LoginProvider, ProviderKey);
                if (user != null)
                {
                    // Clear the dynamic claims cache.
                    await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);
                }

                //return await RedirectSafelyAsync(returnUrl, returnUrlHash);
                return (returnUrl != null)?Redirect(returnUrl): RedirectToPage("/Account/Manage");
            }

            user = await UserManager.FindByLoginAsync(LoginProvider, ProviderKey);
            if (user == null)
            {
                user = new IdentityUser(GuidGenerator.Create(), username, $"{username}@telegram.org", null);
                user.SetProperty("id", id);
                user.SetProperty("first_name", first_name);
                user.SetProperty("last_name", last_name);
                user.SetProperty("username", username);
                user.SetProperty("photo_url", photo_url);
                user.SetProperty("provider", LoginProvider);
                user = await RegisterExternalUserAsync(loginInfo, user );
            }
            //
            //if (user == null)
            //{
            //    return RedirectToPage("/Account/Register", new
            //    {
            //        IsExternalLogin = true,
            //        ExternalLoginAuthSchema = LoginProvider,
            //        ReturnUrl = returnUrl
            //    });
            //}

            if (await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey) == null)
            {
                await UserManager.AddLoginAsync(user, loginInfo);
            }

            await SignInManager.SignInAsync(user, false);

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = user.Name
            });

            //// Clear the dynamic claims cache.
            await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);

            return (returnUrl != null) ? Redirect(returnUrl) : RedirectToPage("/Account/Manage");
            //return await RedirectSafelyAsync(returnUrl, returnUrlHash);
        }
        // return him back to home/index where he will be redirected to login,
        // if the login was unsuccessful
        //return RedirectToAction("index", "home");
        await Task.CompletedTask;
        return Forbid();
    }

    protected async Task<IdentityUser> RegisterExternalUserAsync(ExternalLoginInfo externalLoginInfo, IdentityUser user)
    {
        await IdentityOptions.SetAsync();

        
        (await UserManager.CreateAsync(user)).CheckErrors();
        (await UserManager.AddDefaultRolesAsync(user)).CheckErrors();

        var userLoginAlreadyExists = user.Logins.Any(x =>
            x.TenantId == user.TenantId &&
            x.LoginProvider == externalLoginInfo.LoginProvider &&
            x.ProviderKey == externalLoginInfo.ProviderKey);

        if (!userLoginAlreadyExists)
        {
            (await UserManager.AddLoginAsync(user, new UserLoginInfo(
                externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey,
                externalLoginInfo.ProviderDisplayName
            ))).CheckErrors();
        }

        await SignInManager.SignInAsync(user, isPersistent: true, "Telegram");

        // Clear the dynamic claims cache.
        await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);
        return user;
    }
}

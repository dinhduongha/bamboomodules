//using System;
//using System.Security.Claims;
//using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
//using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;
//using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
//using Volo.Abp.MultiTenancy;
//using Volo.Abp.OpenIddict;
//using Volo.Abp.Security.Claims;

using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Validation;

using IdentityUser = Volo.Abp.Identity.IdentityUser;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

using static Volo.Abp.Identity.IdentityPermissions;
using static Volo.Abp.UI.Navigation.DefaultMenuNames.Application;

//using IdentityModel;
using Telegram.Bot.Extensions.LoginWidget;

namespace Bamboo.Abp.LoginUi.Web.Pages.Account;

public class LoginUiLoginModel : LoginModel
{
    public bool EnableTelegram { get; set; }
    public string TelegramWidget { get; set; }

    public LoginUiLoginModel(
        IConfiguration config,
        IAuthenticationSchemeProvider schemeProvider,
        IOptions<AbpAccountOptions> accountOptions,
        IOptions<IdentityOptions> identityOptions,
        IdentityDynamicClaimsPrincipalContributorCache cache)
        : base(schemeProvider, accountOptions, identityOptions, cache)
    {
        var section = config.GetSection("Telegram");
        WidgetEmbedCodeGenerator.LoginWidgetJsVersion = 22;
        if (section.Exists() && section.GetValue<bool>("IsEnabled", false))
        {
            EnableTelegram = true;
            var botName = section["BotName"];
            var LoginCallback = section["LoginCallback"];
            var useLargeButton = section.GetValue<bool>("Large", false);
            TelegramWidget = WidgetEmbedCodeGenerator.GenerateRedirectEmbedCode(
            botName,
            LoginCallback,            
            useLargeButton?ButtonStyle.Large: ButtonStyle.Medium,
            true,
            true);
        }        
    }

    public override async Task<IActionResult> OnPostExternalLogin(string provider)
    {
        var redirectUrl = Url.Page("./Login", pageHandler: "ExternalLoginCallback", values: new { ReturnUrl, ReturnUrlHash });
        var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        properties.Items["scheme"] = provider;

        return await Task.FromResult(Challenge(properties, provider));
    }

    public override async Task<IActionResult> OnGetExternalLoginCallbackAsync(string returnUrl = "", string returnUrlHash = "", string remoteError = null)
    {
        //return await base.OnGetExternalLoginCallbackAsync(returnUrl, returnUrlHash, remoteError);

        //TODO: Did not implemented Identity Server 4 sample for this method (see ExternalLoginCallback in Quickstart of IDS4 sample)
        /* Also did not implement these:
         * - Logout(string logoutId)
         */

        if (remoteError != null)
        {
            Logger.LogWarning($"External login callback error: {remoteError}");
            return RedirectToPage("./Login");
        }

        await IdentityOptions.SetAsync();

        var loginInfo = await SignInManager.GetExternalLoginInfoAsync();
        if (loginInfo == null)
        {
            Logger.LogWarning("External login info is not available");
            return RedirectToPage("./Login");
        }

        var result = await SignInManager.ExternalLoginSignInAsync(
            loginInfo.LoginProvider,
            loginInfo.ProviderKey,
            isPersistent: false,
            bypassTwoFactor: true
        );

        if (!result.Succeeded)
        {
            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                Action = "Login" + result
            });
        }

        if (result.IsLockedOut)
        {
            Logger.LogWarning($"External login callback error: user is locked out!");
            throw new UserFriendlyException("Cannot proceed because user is locked out!");
        }

        if (result.IsNotAllowed)
        {
            Logger.LogWarning($"External login callback error: user is not allowed!");
            throw new UserFriendlyException("Cannot proceed because user is not allowed!");
        }

        IdentityUser user;
        if (result.Succeeded)
        {
            user = await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey);
            if (user != null)
            {
                // Clear the dynamic claims cache.
                await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);
            }

            return await RedirectSafelyAsync(returnUrl, returnUrlHash);
        }

        //TODO: Handle other cases for result!

        var email = loginInfo.Principal.FindFirstValue(AbpClaimTypes.Email) ?? loginInfo.Principal.FindFirstValue(ClaimTypes.Email);
        if (email.IsNullOrWhiteSpace())
        {
            return RedirectToPage("./Register", new
            {
                IsExternalLogin = true,
                ExternalLoginAuthSchema = loginInfo.LoginProvider,
                ReturnUrl = returnUrl
            });
        }

        user = await UserManager.FindByEmailAsync(email);
        if (user == null)
        {
            return RedirectToPage("./Register", new
            {
                IsExternalLogin = true,
                ExternalLoginAuthSchema = loginInfo.LoginProvider,
                ReturnUrl = returnUrl
            });
        }

        if (await UserManager.FindByLoginAsync(loginInfo.LoginProvider, loginInfo.ProviderKey) == null)
        {
            CheckIdentityErrors(await UserManager.AddLoginAsync(user, loginInfo));
        }

        await SignInManager.SignInAsync(user, false);

        await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
        {
            Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
            Action = result.ToIdentitySecurityLogAction(),
            UserName = user.Name
        });

        // Clear the dynamic claims cache.
        await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);

        return await RedirectSafelyAsync(returnUrl, returnUrlHash);
    }
        //protected override async Task<IdentityUser> CreateExternalUserAsync(ExternalLoginInfo info)
        //{
        //    //ClaimsPrincipal principal;
        //    var emailAddress = info.Principal.FindFirstValue(AbpClaimTypes.Email);
        //    var userId = GuidGenerator.Create();
        //    var user = new IdentityUser(userId, emailAddress, emailAddress, CurrentTenant.Id)
        //    {
        //        // This claim will be null if using AzureAD v2.0 endpoint
        //        Name = info.Principal.FindFirstValue(JwtClaimTypes.GivenName),
        //        // This claim will be null if using AzureAD v2.0 endpoint
        //        Surname = info.Principal.FindFirstValue(JwtClaimTypes.FamilyName),
        //        IsExternal = true
        //    };

        //    //Optional: Add claims to user claims
        //    if (!string.IsNullOrEmpty(info.Principal.FindFirstValue(JwtClaimTypes.GivenName)))
        //    {
        //        user.Claims.Add(new Volo.Abp.Identity.IdentityUserClaim(GuidGenerator.Create(), userId,
        //            JwtClaimTypes.GivenName, info.Principal.FindFirstValue(JwtClaimTypes.GivenName), CurrentTenant.Id));
        //    }

        //    if (!string.IsNullOrEmpty(info.Principal.FindFirstValue(JwtClaimTypes.FamilyName)))
        //    {
        //        user.Claims.Add(new Volo.Abp.Identity.IdentityUserClaim(GuidGenerator.Create(), userId,
        //            JwtClaimTypes.FamilyName, info.Principal.FindFirstValue(JwtClaimTypes.FamilyName),
        //            CurrentTenant.Id));
        //    }

        //    CheckIdentityErrors(await UserManager.CreateAsync(user));
        //    CheckIdentityErrors(await UserManager.SetEmailAsync(user, emailAddress));
        //    CheckIdentityErrors(await UserManager.AddLoginAsync(user, info));

        //    return user;
        //}
    }

//[ExposeServices(typeof(LoginModel))]
//public class LoginUiLoginModel : OpenIddictSupportedLoginModel
//{
//    private readonly ITenantRepository _tenantRepository;

//    public LoginUiLoginModel(
//        IAuthenticationSchemeProvider schemeProvider,
//        IOptions<AbpAccountOptions> accountOptions,
//        IOptions<IdentityOptions> identityOptions,
//        AbpOpenIddictRequestHelper openIddictRequestHelper)
//        : base(schemeProvider, accountOptions, identityOptions, openIddictRequestHelper)
//    {
//        _tenantRepository = tenantRepository;
//    }

//    public override async Task<IActionResult> OnPostAsync(string action)
//    {
//        return await base.OnPostAsync(action);
//        var user = await FindUserAsync(LoginInput.UserNameOrEmailAddress);
//        using (CurrentTenant.Change(user?.TenantId))
//        {
//            return await base.OnPostAsync(action);
//        }
//    }

//    public override async Task<IActionResult> OnGetExternalLoginCallbackAsync(string returnUrl = "", string returnUrlHash = "", string remoteError = null)
//    {
//        var user = await FindUserAsync(LoginInput.UserNameOrEmailAddress);
//        using (CurrentTenant.Change(user?.TenantId))
//        {
//            return await base.OnGetExternalLoginCallbackAsync(returnUrl, returnUrlHash, remoteError);
//        }
//    }

//    protected virtual async Task<IdentityUser> FindUserAsync(string uniqueUserNameOrEmailAddress)
//    {
//        IdentityUser user = null;
//        using (CurrentTenant.Change(null))
//        {
//            user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
//                   await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

//            if (user != null)
//            {
//                return user;
//            }
//        }

//        foreach (var tenant in await _tenantRepository.GetListAsync())
//        {
//            using (CurrentTenant.Change(tenant.Id))
//            {
//                user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
//                       await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

//                if (user != null)
//                {
//                    return user;
//                }
//            }
//        }

//        return null;
//    }
//}
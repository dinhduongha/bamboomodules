using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
namespace Bamboo.Abp.LoginUi.Web.Pages.Account;

public class LoginUiRegisterModel : RegisterModel
{
    public LoginUiRegisterModel(
        IAccountAppService accountAppService,
        IAuthenticationSchemeProvider schemeProvider,
        IOptions<AbpAccountOptions> accountOptions,
        IdentityDynamicClaimsPrincipalContributorCache identityDynamicClaimsPrincipalContributorCache)
        : base(accountAppService, schemeProvider, accountOptions, identityDynamicClaimsPrincipalContributorCache)
    {
    }

    public override async Task<IActionResult> OnGetAsync()
    {
        ExternalProviders = await GetExternalProviders();

        if (!await CheckSelfRegistrationAsync())
        {
            if (IsExternalLoginOnly)
            {
                return await OnPostExternalLogin(ExternalLoginScheme);
            }

            Alerts.Warning(L["SelfRegistrationDisabledMessage"]);
        }

        await TrySetEmailAsync();

        return Page();
    }

    protected override async Task TrySetEmailAsync()
    {
        if (IsExternalLogin)
        {
            var externalLoginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                return;
            }

            if (!externalLoginInfo.Principal.Identities.Any())
            {
                return;
            }

            var identity = externalLoginInfo.Principal.Identities.First();
            var emailClaim = identity.FindFirst(AbpClaimTypes.Email) ?? identity.FindFirst(ClaimTypes.Email);

            if (emailClaim == null)
            {
                return;
            }

            var userName = await UserManager.GetUserNameFromEmailAsync(emailClaim.Value);
            Input = new PostInput { UserName = userName, EmailAddress = emailClaim.Value };
        }
    }

    public override async Task<IActionResult> OnPostAsync()
    {
        try
        {
            ExternalProviders = await GetExternalProviders();

            if (!await CheckSelfRegistrationAsync())
            {
                throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
            }

            if (IsExternalLogin)
            {
                var externalLoginInfo = await SignInManager.GetExternalLoginInfoAsync();
                if (externalLoginInfo == null)
                {
                    Logger.LogWarning("External login info is not available");
                    return RedirectToPage("./Login");
                }
                if (Input.UserName.IsNullOrWhiteSpace())
                {
                    Input.UserName = await UserManager.GetUserNameFromEmailAsync(Input.EmailAddress);
                }
                await RegisterExternalUserAsync(externalLoginInfo, Input.UserName, Input.EmailAddress);
            }
            else
            {
                await RegisterLocalUserAsync();
            }

            return Redirect(ReturnUrl ?? "~/"); //TODO: How to ensure safety? IdentityServer requires it however it should be checked somehow!
        }
        catch (BusinessException e)
        {
            Alerts.Danger(GetLocalizeExceptionMessage(e));
            return Page();
        }
    }
    protected override async Task RegisterExternalUserAsync(ExternalLoginInfo externalLoginInfo, string userName, string emailAddress)
    {
        await IdentityOptions.SetAsync();

        var user = new IdentityUser(GuidGenerator.Create(), userName, emailAddress, CurrentTenant.Id);

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

        await SignInManager.SignInAsync(user, isPersistent: true, ExternalLoginAuthSchema);

        // Clear the dynamic claims cache.
        await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);
    }
}
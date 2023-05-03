using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using Volo.Abp.Security.Claims;

//using IdentityModel;

namespace Bamboo.Abp.LoginUi.Web.Pages.Account;

public class LoginUiLoginModel : LoginModel
{
    public LoginUiLoginModel(IAuthenticationSchemeProvider schemeProvider, IOptions<AbpAccountOptions> accountOptions,
        IOptions<IdentityOptions> identityOptions) : base(schemeProvider, accountOptions, identityOptions)
    {
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
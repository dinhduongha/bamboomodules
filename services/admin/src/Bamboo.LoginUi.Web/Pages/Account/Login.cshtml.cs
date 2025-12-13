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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using Volo.Abp.Data;
namespace Bamboo.Abp.LoginUi.Web.Pages.Account;

public class LoginUiLoginModel : LoginModel
{
    public bool EnableTelegram { get; set; }
    public string TelegramWidget { get; set; }

    private readonly IConfiguration _configuration;
    public LoginUiLoginModel(
        IConfiguration configuration,
        IAuthenticationSchemeProvider schemeProvider,
        IOptions<AbpAccountOptions> accountOptions,
        IOptions<IdentityOptions> identityOptions,
        IdentityDynamicClaimsPrincipalContributorCache cache, IWebHostEnvironment webHostEnvironment)
        : base(schemeProvider, accountOptions, identityOptions, cache, webHostEnvironment)
    {
        _configuration = configuration;
        var section = _configuration.GetSection("Telegram");
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
            useLargeButton ? ButtonStyle.Large : ButtonStyle.Medium,
            true,
            true);
        }
    }

    [HttpGet("siwx")]
    public IActionResult Siwx(string returnUrl = null)
    {
        // var redirectUrl = Url.Page("/Account/SiWXSignIn", new { returnUrl });
        // var properties = SignInManager.ConfigureExternalAuthenticationProperties(
        //     provider: "SIWX",
        //     redirectUrl: redirectUrl
        // );

        // return new ChallengeResult("SIWX", properties);
        return RedirectToPage("/Account/SiWXSignIn", new { returnUrl = returnUrl });
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
            return RedirectToPage("./Login", new { ReturnUrl = returnUrl, ReturnUrlHash = returnUrlHash });
        }

        await IdentityOptions.SetAsync();

        var loginInfo = await SignInManager.GetExternalLoginInfoAsync();
        if (loginInfo == null)
        {
            Logger.LogWarning("External login info is not available");
            return RedirectToPage("./Login", new { ReturnUrl = returnUrl, ReturnUrlHash = returnUrlHash });
        }

        var result = await SignInManager.ExternalLoginSignInAsync(
            loginInfo.LoginProvider,
            loginInfo.ProviderKey,
            isPersistent: false,
            bypassTwoFactor: true
        );

        if (result.Succeeded)
        {
            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                Action = "Login" + result
            });
            return await RedirectSafelyAsync(returnUrl, returnUrlHash);
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

        var isAutoExternalAccount = _configuration.GetValue("App:AutoExternalAccount", true);
        var isAutoExternalAccountHostOnly = _configuration.GetValue("App:AutoExternalAccountHostOnly", true);
        if (isAutoExternalAccountHostOnly && CurrentTenant.IsAvailable)
        {
            throw new UserFriendlyException("Cannot create tenant's account!");
        }
        if (isAutoExternalAccount)
        {
            // A. TRÍCH XUẤT CLAIMS (User Data)
            var claims = loginInfo.Principal;

            // 1. Lấy SUB (Provider Key - ID duy nhất)
            // ABP đã map nó vào loginInfo.ProviderKey, đây là cái an toàn nhất để link
            var providerKey = loginInfo.ProviderKey;
            var provider = loginInfo.LoginProvider;

            // 2. Lấy Email (để lưu vào profile, không dùng để link account nếu muốn bảo mật tuyệt đối)
            var email = claims.FindFirstValue(ClaimTypes.Email);

            // 3. Lấy Tên họ
            var givenName = claims.FindFirstValue(ClaimTypes.GivenName) ?? ""; // Tên
            var surname = claims.FindFirstValue(ClaimTypes.Surname) ?? "";     // Họ
            var name = claims.FindFirstValue(ClaimTypes.Name) ?? "";           // Full Name

            // Fallback: Nếu tách họ tên bị rỗng, thử dùng Name để split (tùy logic dự án)
            if (string.IsNullOrEmpty(givenName) && !string.IsNullOrEmpty(name))
            {
                givenName = name; // Tạm gán
            }

            // B. TẠO USERNAME SẠCH (A-Z, 0-9)
            // Logic: combine "Ho" + "Ten" + "4 số cuối của Sub" để tránh trùng
            string cleanName = NormalizeToEnglish(name);
            string cleanSurname = NormalizeToEnglish(surname);
            string cleanGivenName = NormalizeToEnglish(givenName);

            // Lấy 4-6 ký tự cuối của Sub (ProviderKey) để đảm bảo unique
            string uniqueSuffix = providerKey.Length > 5
                ? providerKey.Substring(providerKey.Length - 5)
                : new Random().Next(1000, 9999).ToString();

            // Ví dụ kết quả: nguyenvana12345
            string safeUserName = !string.IsNullOrWhiteSpace(cleanName) ? $"{cleanName}{uniqueSuffix}{provider.ToLower()}" : $"{cleanSurname}{cleanGivenName}{uniqueSuffix}{provider.ToLower()}";
            //string safeUserName = NormalizeToEnglish($"{providerKey}-{provider}");
            string emailLocal = $"noemail_{safeUserName}@dad.local";
            // Nếu chuỗi rỗng (trường hợp user ko có tên), dùng fallback
            if (string.IsNullOrWhiteSpace(safeUserName))
            {
                safeUserName = $"user{Guid.NewGuid().ToString("N").Substring(0, 8)}";
            }

            // C. TẠO USER
            // Lưu ý: ABP mặc định dùng Email làm Username, ta sẽ override bằng safeUserName
            var user = new IdentityUser(GuidGenerator.Create(), safeUserName, emailLocal ?? $"noemail_{safeUserName}@dad.local", CurrentTenant.Id);

            // Set lại Name/Surname cho đẹp (giữ nguyên unicode để hiển thị)
            user.Name = !string.IsNullOrWhiteSpace(name) ? name : givenName + " " + surname;
            user.Surname = surname;
            user.IsExternal = true;
            var info = new
            {
                key = providerKey,
                provider = provider,
                email = email,
                givenname = givenName,
                surname = surname,
                name = name
            };
            user.SetProperty("info", info);

            // user.SetEmailConfirmed(true); 

            var createResult = await UserManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                // Quan trọng: Link User với ProviderKey (SUB)
                // Lần sau login, ABP sẽ check bảng UserLogins dựa trên ProviderKey này
                var addLoginResult = await UserManager.AddLoginAsync(user, loginInfo);

                if (addLoginResult.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return await RedirectSafelyAsync(returnUrl, returnUrlHash);
                }
            }
            else
            {
                // Log lỗi createResult.Errors để debug
                foreach (var error in createResult.Errors)
                {
                    Alerts.Warning(error.Description);
                }
            }
        }
        if (isAutoExternalAccount && false)
        {
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
        return await base.OnGetExternalLoginCallbackAsync(returnUrl, returnUrlHash, remoteError);
    }


    private string NormalizeToEnglish(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        // 1. Chuẩn hóa unicode để tách dấu ra khỏi ký tự gốc
        string normalizedString = input.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            // Lấy các ký tự không phải là dấu (NonSpacingMark)
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        // 2. Chuyển về dạng chuẩn C, lowercase
        string result = stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();

        // 3. Xử lý riêng ký tự đ/Đ của tiếng Việt (nếu bước 1 chưa xử lý hết các edge case)
        result = result.Replace("đ", "d");

        // 4. Dùng Regex chỉ giữ lại a-z và 0-9
        // Pattern: [^a-z0-9] nghĩa là tìm ký tự KHÔNG phải a-z, 0-9 và replace bằng rỗng
        result = Regex.Replace(result, "[^a-z0-9]", "");

        return result;
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
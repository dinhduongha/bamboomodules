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
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
namespace Bamboo.Abp.LoginUi.Web.Pages.Account;

public class LoginUiRegisterModel : RegisterModel
{
    private const string SiwxProviderName = "SIWX";
    private readonly ICurrentTenant _currentTenant;
    public LoginUiRegisterModel(
        ICurrentTenant currentTenant,
        IAccountAppService accountAppService,
        IAuthenticationSchemeProvider schemeProvider,
        IOptions<AbpAccountOptions> accountOptions,
        IdentityDynamicClaimsPrincipalContributorCache identityDynamicClaimsPrincipalContributorCache)
        : base(accountAppService, schemeProvider, accountOptions, identityDynamicClaimsPrincipalContributorCache)
    {
        _currentTenant = currentTenant;
    }

    public override async Task<IActionResult> OnGetAsync()
    {
        if (_currentTenant.IsAvailable)
        {
            return RedirectToPage("/Account/Login", new
            {
                ReturnUrl = ReturnUrl,
                ReturnUrlHash = ReturnUrlHash
            });
        }
        // --- BƯỚC 1: KIỂM TRA SIWX TRƯỚC (ƯU TIÊN SỐ 1) ---
        // Check cookie xem có phải user đang redirect từ trang ký ví sang không
        var authResult = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

        if (authResult.Succeeded && authResult.Principal != null)
        {
            var loginProvider = authResult.Properties?.Items["LoginProvider"];

            if (loginProvider == SiwxProviderName)
            {
                // ======
                // Nếu là SIWX, ta BỎ QUA logic check EnableLocalRegister của ABP.
                // Setup Model và return Page().

                IsExternalLogin = true;

                var address = authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                var network = authResult.Properties?.Items["ProviderDisplayName"] ?? "Wallet";

                // Điền Form
                Input = new PostInput { };
                //Input = new PostInput { UserName = address, EmailAddress = $"{address}@siwx.local" };

                // Hack: Thêm SIWX vào danh sách Provider ảo để UI không bị ẩn 
                // (Nếu UI của bạn check ExternalProviders.Any())
                ExternalProviders = new List<ExternalProviderModel>
                {
                    new ExternalProviderModel { AuthenticationScheme = SiwxProviderName, DisplayName = network }
                };

                // KHÔNG gọi base.OnGetAsync() để tránh bị chặn
                return Page();
            }
        }

        // --- BƯỚC 2: NẾU KHÔNG PHẢI SIWX và EnableLocalRegister == False  ---
        // Gọi logic gốc để xử lý các case còn lại (Google, Local register bị cấm...)
        return await base.OnGetAsync();
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
        if (_currentTenant.IsAvailable)
        {
            return RedirectToPage("/Account/Login", new
            {
                ReturnUrl = ReturnUrl,
                ReturnUrlHash = ReturnUrlHash
            });
        }
        // === LOGIC TẠO USER CHO SIWX ===
        try
        {
            // Check lại Cookie để xác định flow
            var authResult = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);
            var isSiwx = authResult.Succeeded && authResult.Properties?.Items["LoginProvider"] == SiwxProviderName;

            if (!isSiwx)
            {
                // Nếu không phải SIWX thì chạy logic chuẩn (Google/Local)
                return await base.OnPostAsync();
            }

            // Validate Input
            // ValidateModel();

            // === LOGIC XỬ LÝ SIWX (Override) ===
            // 3. Bypass kiểm tra "CheckSelfRegistrationAsync" 
            // (Để vượt qua rào cản EnableLocalRegister = false)
            // Ta không gọi: if (!await CheckSelfRegistrationAsync()) ...

            // 4. CHẾ TẠO "ExternalLoginInfo" THỦ CÔNG
            // Vì SignInManager.GetExternalLoginInfoAsync() có thể trả về null với custom cookie,
            // ta tự tạo object này từ dữ liệu authResult ta đang có.

            var address = authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var network = authResult.Properties?.Items["ProviderDisplayName"] ?? "Wallet";

            var externalLoginInfo = new ExternalLoginInfo(
                authResult.Principal,
                SiwxProviderName,
                address,
                network)
            {
                AuthenticationProperties = authResult.Properties
            };

            // 5. GỌI HÀM CHUẨN CỦA ABP
            // Hàm này sẽ lo việc: Tạo User, Validate, Link Ví (AddLogin), SignIn
            await RegisterExternalUserAsync(externalLoginInfo, Input.UserName, Input.EmailAddress);

            // 6. Redirect an toàn
            return await RedirectSafelyAsync(ReturnUrl, ReturnUrlHash);
        }
        catch (UserFriendlyException e)
        {
            Alerts.Danger(e.Message);
            return Page();
        }

    }
    // protected override async Task RegisterExternalUserAsync(ExternalLoginInfo externalLoginInfo, string userName, string emailAddress)
    // {
    //     await IdentityOptions.SetAsync();

    //     var user = new IdentityUser(GuidGenerator.Create(), userName, emailAddress, CurrentTenant.Id);

    //     (await UserManager.CreateAsync(user)).CheckErrors();
    //     (await UserManager.AddDefaultRolesAsync(user)).CheckErrors();

    //     var userLoginAlreadyExists = user.Logins.Any(x =>
    //         x.TenantId == user.TenantId &&
    //         x.LoginProvider == externalLoginInfo.LoginProvider &&
    //         x.ProviderKey == externalLoginInfo.ProviderKey);

    //     if (!userLoginAlreadyExists)
    //     {
    //         (await UserManager.AddLoginAsync(user, new UserLoginInfo(
    //             externalLoginInfo.LoginProvider,
    //             externalLoginInfo.ProviderKey,
    //             externalLoginInfo.ProviderDisplayName
    //         ))).CheckErrors();
    //     }

    //     await SignInManager.SignInAsync(user, isPersistent: true, ExternalLoginAuthSchema);

    //     // Clear the dynamic claims cache.
    //     await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);
    // }
}
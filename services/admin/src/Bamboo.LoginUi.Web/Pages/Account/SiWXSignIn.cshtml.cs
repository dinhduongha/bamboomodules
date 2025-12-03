using System;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

using Volo.Abp.Identity;
using Volo.Abp.Guids;    // BouncyCastle cho Ed25519

using IdentityUser = Volo.Abp.Identity.IdentityUser;

using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Account;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web;
using Bamboo.Abp.LoginUi.Services;
using Nethereum.Signer;

namespace Bamboo.Abp.LoginUi.Web.Pages.Account.SiWX;

[AllowAnonymous]
[IgnoreAntiforgeryToken]
public class SiWXSignInModel : AccountPageModel
{
    [BindProperty(SupportsGet = true)]
    public string ReturnUrl { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ReturnUrlHash { get; set; }

    [BindProperty]
    public string SessionHandle { get; set; }

    // private SignInManager<IdentityUser> SignInManager { get; }
    private UserManager<IdentityUser> UserManager { get; }
    private ILogger<SiWXSignInModel> Logger { get; }
    protected IGuidGenerator _guidGenerator { get; }
    private readonly IWeb3AuthService _web3AuthService;


    public SiWXSignInModel(
        IAccountAppService accountAppService,
        IAuthenticationSchemeProvider schemeProvider,
        IOptions<AbpAccountOptions> accountOptions,
        IdentityDynamicClaimsPrincipalContributorCache identityDynamicClaimsPrincipalContributorCache,
        IGuidGenerator guidGenerator,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IWeb3AuthService web3AuthService,
        ILogger<SiWXSignInModel> logger) : base()
    {
        SignInManager = signInManager;
        UserManager = userManager;
        Logger = logger;
        _guidGenerator = guidGenerator;
        _web3AuthService = web3AuthService;
    }

    public IActionResult OnGet()
    {
        // var props = SignInManager.ConfigureExternalAuthenticationProperties("SIWX");
        // if (props == null) return RedirectToPage("/Account/Login");

        // 1. Gọi Service tạo Nonce & Cache
        var result = _web3AuthService.GenerateAndCacheNonce();

        // 2. Đẩy dữ liệu ra View
        SessionHandle = result.Handle;
        ViewData["Nonce"] = result.Nonce;
        ViewData["IssuedAt"] = DateTimeOffset.UtcNow.ToString("o");
        var now = DateTimeOffset.UtcNow;
        var exp = now.AddMinutes(5);
        // props.Items["siwx_nonce"] = nonce;
        // props.Items["siwx_issued_at"] = now.ToString("o");
        // props.Items["siwx_expiration"] = exp.ToString("o");

        // SignInManager.StoreExternalAuthenticationProperties("SIWX", props);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true, // JS không đọc được, bảo mật
            Secure = true,   // Chỉ chạy trên HTTPS
            Expires = exp,
            SameSite = SameSiteMode.Strict
        };

        Response.Cookies.Append("SIWX_NONCE", result.Nonce, cookieOptions);

        ViewData["Nonce"] = result.Nonce;
        ViewData["IssuedAt"] = now.ToString("o");
        ViewData["Expiration"] = exp.ToString("o");
        ViewData["ReturnUrl"] = ReturnUrl;
        ViewData["ReturnUrlHash"] = ReturnUrlHash;
        return Page();
    }

    public async Task<IActionResult> OnPostCallbackAsync(string siwxMessage, string signature, string address, string network, string publicKey)
    {
        // var props = SignInManager.GetExternalAuthenticationProperties("SIWX");
        // if (props?.Items["siwx_nonce"] is not string nonce)
        //     return BadRequest("Invalid state");

        var serverNonce = Request.Cookies["SIWX_NONCE"];
        var msg = JsonSerializer.Deserialize<SiwxMessageDto>(siwxMessage)!;

        // Security checks
        // if (msg.Nonce != serverNonce) return BadRequest("Wrong nonce");
        // if (!msg.Domain.Equals(Request.Host.Value, StringComparison.OrdinalIgnoreCase)) return BadRequest("Domain mismatch");
        // //if (msg.ExpirationTime.HasValue && DateTimeOffset.UtcNow > msg.ExpirationTime.Value) return BadRequest("Expired");

        // var prepared = msg.ToSiweString();

        // bool valid = VerifySignature(prepared, signature, msg.Address);
        // if (!valid) return BadRequest("Invalid signature");
        // 1. Gọi Service verify
        var signingResult = await _web3AuthService.VerifyLoginAsync(SessionHandle, siwxMessage, signature, address, network, publicKey);

        if (!signingResult.Success)
        {
            // Thêm lỗi vào Model State để hiển thị ra UI
            ModelState.AddModelError(string.Empty, signingResult.ErrorMessage);

            // Quan trọng: Refresh lại trang để sinh Nonce mới (vì Nonce cũ đã bị xóa)
            OnGet();
            return Page();
        }

        var props = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
        };
        var info = new ExternalLoginInfo(
            principal: null!,
            loginProvider: "SIWX",
            providerKey: msg.Address,
            displayName: network
        )
        {
            AuthenticationProperties = props
        };

        var result = await SignInManager.ExternalLoginSignInAsync("SIWX", msg.Address, isPersistent: false, bypassTwoFactor: true);
        if (!result.Succeeded)
        {
            var user = new IdentityUser(_guidGenerator.Create(), msg.Address.Truncate(16), $"{msg.Address.ToLower()}@siwx.local");
            await UserManager.CreateAsync(user);
            await UserManager.AddLoginAsync(user, info);
            await SignInManager.SignInAsync(user, isPersistent: false);
        }

        Logger.LogInformation("SIWX login success: {Address}", msg.Address);

        return Redirect("~/connect/authorize/callback" + Request.QueryString);
    }



}

// DTO
public class SiwxMessageDto
{
    public string Domain { get; set; } = "";
    public string Address { get; set; } = "";
    public string? Statement { get; set; }
    public string Uri { get; set; } = "";
    public string Version { get; set; } = "";
    public object? ChainId { get; set; }
    public string Nonce { get; set; } = "";
    public string IssuedAt { get; set; } = "";
    public string? ExpirationTime { get; set; }

    public string ToSiweString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Domain} wants you to sign in with your account:");
        sb.AppendLine(Address);
        if (!string.IsNullOrEmpty(Statement)) sb.AppendLine("\n" + Statement);
        sb.AppendLine($"\nURI: {Uri}");
        sb.AppendLine($"Version: {Version}");
        if (ChainId != null) sb.AppendLine($"Chain ID: {ChainId}");
        sb.AppendLine($"Nonce: {Nonce}");
        sb.AppendLine($"Issued At: {IssuedAt}");
        if (ExpirationTime != null) sb.AppendLine($"Expiration Time: {ExpirationTime}");
        return sb.ToString().TrimEnd();
    }
}

// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Volo.Abp.Identity;

// namespace YourApp.AuthServer.Pages.Account;

// public class SiWXSignInModel : PageModel
// {
//     private readonly SignInManager<IdentityUser> _signInManager;
//     private readonly UserManager<IdentityUser> _userManager;
//     private readonly ILogger<SiWXSignInModel> _logger;

//     public SiWXSignInModel(
//         SignInManager<IdentityUser> signInManager,
//         UserManager<IdentityUser> userManager,
//         ILogger<SiWXSignInModel> logger)
//     {
//         _signInManager = signInManager;
//         _userManager = userManager;
//         _logger = logger;
//     }

//     // Sinh nonce NGAY TẠI ĐÂY khi người dùng vào trang
//     public IActionResult OnGet(string? returnUrl = null)
//     {
//         // Lấy AuthenticationProperties từ flow OpenIddict
//         var properties = _signInManager.GetExternalAuthenticationProperties("SIWX");
//         if (properties == null)
//             return RedirectToPage("/Account/Login");

//         // SINH NONCE TẠI ĐÂY
//         var nonce = Guid.NewGuid().ToString("N");
//         var issuedAt = DateTimeOffset.UtcNow;
//         var expiration = issuedAt.AddMinutes(5);

//         properties.Items["siwx_nonce"] = nonce;
//         properties.Items["siwx_issued_at"] = issuedAt.ToString("o");
//         properties.Items["siwx_expiration"] = expiration.ToString("o");

//         // Lưu lại properties (rất quan trọng!)
//         _signInManager.StoreExternalAuthenticationProperties("SIWX", properties);

//         ViewData["Nonce"] = nonce;
//         ViewData["IssuedAt"] = issuedAt.ToString("o");
//         ViewData["Expiration"] = expiration.ToString("o");

//         return Page();
//     }

//     public async Task<IActionResult> OnPostCallbackAsync(
//         [FromForm] string siwxMessage,
//         [FromForm] string signature)
//     {
//         var properties = _signInManager.GetExternalAuthenticationProperties("SIWX");
//         if (properties?.Items["siwx_nonce"] is not string storedNonce)
//             return BadRequest("Invalid state");

//         {
//             return BadRequest("Invalid state");
//         }

//         // Parse message
//         var msg = JsonSerializer.Deserialize<SiweMessageDto>(siwxMessage)!;

//         // Kiểm tra nonce, domain, thời gian...
//         if (msg.Nonce != storedNonce) return BadRequest("Invalid nonce");
//         if (!msg.Domain.Equals(Request.Host.Value, StringComparison.OrdinalIgnoreCase)) return BadRequest("Domain mismatch");
//         if (msg.ExpirationTime.HasValue && DateTimeOffset.UtcNow > msg.ExpirationTime.Value) return BadRequest("Expired");

//         // Xác minh chữ ký (giữ nguyên hàm verify như trước)
//         bool isValid = VerifySignature(msg, signature);
//         if (!isValid) return BadRequest("Invalid signature");

//         // Tạo external login info
//         var info = new ExternalLoginInfo(
//             principal: null!,
//             loginProvider: "SIWX",
//             providerKey: msg.Address,
//             displayName: DetectChainName(msg.Address)
//         );
//         info.AuthenticationProperties = properties;

//         // Đăng nhập hoặc tạo user
//         var result = await _signInManager.ExternalLoginSignInAsync("SIWX", msg.Address, isPersistent: false, bypassTwoFactor: true);
//         if (!result.Succeeded)
//         {
//             var user = new IdentityUser(Guid.NewGuid(), msg.Address.Truncate(16), $"{msg.Address.ToLower()}@siwx.local");
//             await _userManager.CreateAsync(user);
//             await _userManager.AddLoginAsync(user, info);
//             await _signInManager.SignInAsync(user, isPersistent: false);
//         }

//         // Quan trọng: tiếp tục OpenIddict authorization flow
//         return Redirect("~/connect/authorize/callback" + Request.QueryString);
//     }

//     // Các hàm VerifySignature, DetectChainName... giữ nguyên như file trước
// }
using System;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Security.Claims;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

using Volo.Abp.Identity;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Account;

using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;

using Bamboo.Abp.LoginUi.Services;

using IdentityUser = Volo.Abp.Identity.IdentityUser;
using System.Linq;

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

    public bool EnableEip6963 { get; set; }
    public bool EnableWalletConnect { get; set; }
    public string WalletConnectProjectId { get; set; }

    public List<WalletConnectChainDto> WalletConnectChains { get; set; } = new();

    // private SignInManager<IdentityUser> SignInManager { get; }
    // private UserManager<IdentityUser> UserManager { get; }
    // private ILogger<SiWXSignInModel> Logger { get; }

    private readonly ICurrentTenant _currentTenant;
    protected IGuidGenerator _guidGenerator { get; }
    private readonly IWeb3AuthService _web3AuthService;
    private readonly IConfiguration _configuration;

    public SiWXSignInModel(
        IConfiguration configuration,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant,
        //IAccountAppService accountAppService,
        //IAuthenticationSchemeProvider schemeProvider,
        //IOptions<AbpAccountOptions> accountOptions,
        //IdentityDynamicClaimsPrincipalContributorCache identityDynamicClaimsPrincipalContributorCache,
        //SignInManager<IdentityUser> signInManager,
        //UserManager<IdentityUser> userManager,
        //ILogger<SiWXSignInModel> logger,
        IWeb3AuthService web3AuthService
        ) : base()
    {
        //SignInManager = signInManager;
        //UserManager = userManager;
        //Logger = logger;
        _configuration = configuration;
        _currentTenant = currentTenant;
        _guidGenerator = guidGenerator;
        _web3AuthService = web3AuthService;
    }

    public IActionResult OnGet()
    {

        if (_currentTenant.IsAvailable)
        {
            return RedirectToPage("/Account/Login", new
            {
                ReturnUrl = ReturnUrl,
                ReturnUrlHash = ReturnUrlHash
            });
        }

        EnableEip6963 = _configuration.GetValue<bool>("Blockchain:EnableEip6963");
        EnableWalletConnect = _configuration.GetValue<bool>("Blockchain:EnableWalletConnect");
        WalletConnectProjectId = _configuration["Blockchain:WalletConnectProjectId"];

        var chains = _configuration.GetSection("Blockchain:WalletConnectChains")
                                           .Get<List<WalletConnectChainDto>>();

        if (chains != null && chains.Any())
        {
            WalletConnectChains = chains;
        }
        else
        {
            // Fallback: Nếu quên config thì mặc định là Mainnet để không lỗi JS
            WalletConnectChains.Add(new WalletConnectChainDto
            {
                ChainId = 1,
                Name = "Ethereum",
                Currency = "ETH",
                ExplorerUrl = "https://etherscan.io",
                RpcUrl = "https://eth.llamarpc.com"
            });
        }

        // 1. Gọi Service tạo Nonce & Cache
        var result = _web3AuthService.GenerateAndCacheNonce();
        // 2. Đẩy dữ liệu ra View
        SessionHandle = result.Handle;
        ViewData["Nonce"] = result.Nonce;
        ViewData["IssuedAt"] = DateTimeOffset.UtcNow.ToString("o");
        var now = DateTimeOffset.UtcNow;
        var exp = now.AddMinutes(5);

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

    public async Task<IActionResult> OnPostAsync(string siwxJson, string signature, string address, string network, string publicKey)
    {

        if (_currentTenant.IsAvailable)
        {
            return RedirectToPage("/Account/Login", new
            {
                ReturnUrl = ReturnUrl,
                ReturnUrlHash = ReturnUrlHash
            });
        }

        SiwxMessageDto? dto = null;
        try
        {
            // CaseInsensitive để map đúng camelCase từ JS
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            dto = JsonSerializer.Deserialize<SiwxMessageDto>(siwxJson, options);
        }
        catch
        {
            TempData["Error"] = "Invalid message format.";
            return RedirectToPage(new { ReturnUrl, ReturnUrlHash });
        }

        if (dto == null) return RedirectToPage(new { ReturnUrl, ReturnUrlHash });

        string messageVerify = dto.ToSiweString(_web3AuthService.IsEvm(network));

        var signingResult = await _web3AuthService.VerifyLoginAsync(SessionHandle, messageVerify, signature, address, network, publicKey);

        if (!signingResult.Success)
        {
            // Thêm lỗi vào Model State để hiển thị ra UI
            // Quan trọng: Refresh lại trang để sinh Nonce mới (vì Nonce cũ đã bị xóa)

            ModelState.AddModelError(string.Empty, signingResult.ErrorMessage);
            TempData["Error"] = signingResult.ErrorMessage;
            return RedirectToPage(new { ReturnUrl, ReturnUrlHash });
        }
        if (User.Identity.IsAuthenticated)
        {
            // === CASE A: ĐANG LOGIN (LINK VÍ) ===
            return await LinkWalletToCurrentUserAsync(address, network);
        }
        // 1. Chuẩn bị Properties cho Session (Lưu vào Cookie)
        var propsAuth = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
        };

        // Lưu token/claims vào properties nếu cần thiết (Optional)
        // propsAuth.StoreTokens(new[] { new AuthenticationToken { Name = "siwx_sig", Value = signature } });

        // 2. THỬ LOGIN BẰNG VÍ (Kiểm tra xem ví này đã link với user nào chưa)
        // LoginProvider = "SIWX", ProviderKey = address
        var result = await SignInManager.ExternalLoginSignInAsync(
            loginProvider: "SIWX",
            providerKey: address,
            isPersistent: true,
            bypassTwoFactor: true
        );

        if (result.Succeeded)
        {
            Logger.LogInformation("SIWX: Ví {Address} đã tồn tại. Login thành công.", address);
            return RedirectToReturnUrl(ReturnUrl);
        }

        // 3. NẾU CHƯA CÓ -> TẠO USER MỚI & LINK VÍ
        if (result.IsLockedOut)
        {
            Logger.LogWarning("SIWX: Ví {Address} đang bị khóa.", address);
            return RedirectToPage("./LockedOut");
        }
        else
        {
            bool autoWalletAccount = _configuration.GetValue<bool>("Blockchain:AutoWalletAccount");
            if (!autoWalletAccount)
            {
                // === CASE A: REDIRECT TO REGISTER (Giống Google) ===

                // Bước B1: Tạo danh tính tạm (Identity) cho Ví
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, address), // ID là ví
                    new Claim(ClaimTypes.Name, address),           // Tên hiển thị là ví
                    // Bạn có thể thêm Claim Network nếu muốn Register page biết
                    new Claim("Network", network)
                };
                var identity = new ClaimsIdentity(claims, IdentityConstants.ExternalScheme);
                var principal = new ClaimsPrincipal(identity);

                // Bước B2: Đóng gói thông tin Provider vào Properties
                // Đây là chuẩn của ASP.NET Core Identity để hàm GetExternalLoginInfoAsync đọc được
                var props = new AuthenticationProperties();
                props.RedirectUri = ReturnUrl;
                props.Items["LoginProvider"] = "SIWX";  // Tên Provider
                props.Items["ProviderKey"] = address;   // Khóa chính (Address)
                props.Items["ProviderDisplayName"] = network;   // Tên hiển thị (Ethereum/Solana...)

                // Bước B3: Đăng nhập vào Scheme TẠM (Identity.External)
                // Lưu ý: Đây chưa phải là login vào App, chỉ là login tạm để chuyển dữ liệu
                await HttpContext.SignInAsync(IdentityConstants.ExternalScheme, principal, props);

                // Bước B4: Chuyển hướng sang trang Register
                // Trang Register của ABP sẽ tự động check External Cookie và hiển thị form điền Email
                return RedirectToPage("/Account/Register", new { ReturnUrl = ReturnUrl });
            }
            // B. Tự động tạo User mới
            // Lưu ý: Email ví dụ, có thể custom theo logic dự án
            var user = new IdentityUser(
                id: _guidGenerator.Create(),
                userName: address, // Username là địa chỉ ví
                email: $"{address.ToLower()}@siwx.local",
                tenantId: _currentTenant.Id // Quan trọng cho Multi-tenancy
            );

            // Mark email confirmed để tránh bị chặn đăng nhập nếu có setting bắt buộc
            user.SetEmailConfirmed(true);

            var createResult = await UserManager.CreateAsync(user);
            if (!createResult.Succeeded)
            {
                // Xử lý lỗi tạo user (ví dụ trùng username...)
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToPage(new { ReturnUrl, ReturnUrlHash });
                //return Page();
            }

            // C. Link Ví vào User vừa tạo (AddLoginAsync)
            // Dùng UserLoginInfo thay vì ExternalLoginInfo cho gọn
            var loginInfo = new UserLoginInfo(loginProvider: "SIWX", providerKey: address, providerDisplayName: network);
            var addLoginResult = await UserManager.AddLoginAsync(user, loginInfo);
            if (!addLoginResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Không thể liên kết ví với tài khoản.");
                return RedirectToPage(new { ReturnUrl, ReturnUrlHash });
                //return Page();
            }

            // D. Login ngay lập tức
            await SignInManager.SignInAsync(user, propsAuth);

            Logger.LogInformation("SIWX: Tạo mới user {Address} thành công.", address);

            // 4. REDIRECT VỀ CLIENT (OAUTH FLOW)
            return RedirectToReturnUrl(ReturnUrl);
        }

    }

    // Hàm Helper xử lý Redirect an toàn
    private IActionResult RedirectToReturnUrl(string returnUrl)
    {
        // Nếu ReturnUrl có giá trị (từ OpenIddict gửi sang), quay về đó
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        // Nếu không có, về trang chủ
        return Redirect("~/");
    }
    // --- HÀM XỬ LÝ LINK VÍ (MỚI) ---
    private async Task<IActionResult> LinkWalletToCurrentUserAsync(string address, string network)
    {
        // 1. Lấy User hiện tại (Đang login bằng Google)
        var currentUser = await UserManager.GetUserAsync(User);
        if (currentUser == null) return RedirectToPage("/Account/Login");

        // 2. Kiểm tra xem Ví này đã gắn vào tài khoản KHÁC chưa?
        // Nguyên tắc: 1 Ví chỉ thuộc về 1 User.
        var ownerOfWallet = await UserManager.FindByLoginAsync("SIWX", address);

        if (ownerOfWallet != null && ownerOfWallet.Id != currentUser.Id)
        {
            TempData["Error"] = "Ví này đã được liên kết với một tài khoản khác!";
            return RedirectToPage(new { ReturnUrl, ReturnUrlHash });
        }

        if (ownerOfWallet != null && ownerOfWallet.Id == currentUser.Id)
        {
            TempData["Success"] = "Ví này đã được liên kết với bạn rồi.";
            return Redirect(ReturnUrl ?? "/Account/Manage");
        }

        // 3. THỰC HIỆN LINK (AddLogin)
        var loginInfo = new UserLoginInfo("SIWX", address, network);
        var result = await UserManager.AddLoginAsync(currentUser, loginInfo);

        if (result.Succeeded)
        {
            // (Tùy chọn) Refresh lại Cookie để cập nhật Claims mới nếu cần
            await SignInManager.RefreshSignInAsync(currentUser);

            TempData["Success"] = "Liên kết ví thành công!";
            // Redirect về trang quản lý tài khoản hoặc ReturnUrl
            return Redirect(ReturnUrl ?? "/Account/Manage");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToPage(new { ReturnUrl, ReturnUrlHash });
        }
    }
}

public class WalletConnectChainDto
{
    public int ChainId { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
    public string ExplorerUrl { get; set; }
    public string RpcUrl { get; set; }
}
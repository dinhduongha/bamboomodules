using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Abp.Uow;
using OpenIddict.Abstractions;
using System.Security.Claims;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.MultiTenancy;
using System.Collections.Immutable;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using Volo.Abp.OpenIddict.Controllers;
using OpenIddict.Server.AspNetCore;
using Volo.Abp.OpenIddict.Tokens;
using System.Threading.Tasks;
using System;

namespace Bamboo.Admin.Controllers;

[NonController]
[Route("/connect/account")]
[ApiController]
public class CustomLoginController : AbpOpenIdDictControllerBase
{
    //private readonly SignInManager<IdentityUser> _signInManager;
    //private readonly IdentityUserManager _userManager;
    private readonly ICurrentTenant _currentTenant;
    //private readonly IOpenIddictTokenManager _tokenManager;
    //private readonly IOpenIddictAuthorizationManager _authorizationManager;

    public CustomLoginController(
        SignInManager<IdentityUser> signInManager,
        //IdentityUserManager userManager,
        ICurrentTenant currentTenant
        //IOpenIddictTokenManager tokenManager,
        //IOpenIddictAuthorizationManager authorizationManager
        )
    {
        //_signInManager = signInManager;
        //_userManager = userManager;
        _currentTenant = currentTenant;
        //_tokenManager = tokenManager;
        //_authorizationManager = authorizationManager;
    }
    private readonly IOpenIddictTokenStore<OpenIddictTokenModel> _tokenStore; // Quan trọng: Để lưu payload
    [HttpPost("login-token")]
    [UnitOfWork]
    public async Task<IActionResult> LoginToken([FromBody] LoginDto input)
    {
        var user = await UserManager.FindByNameAsync(input.UserName);
        if (user == null)
            return Unauthorized(new { error = "Invalid username or password" });

        var result = await SignInManager.CheckPasswordSignInAsync(user, input.Password, true);
        if (!result.Succeeded)
            return Unauthorized(new { error = "Invalid username or password" });

        // Tạo ClaimsPrincipal từ user
        var principal = await SignInManager.CreateUserPrincipalAsync(user);
        var identity = (ClaimsIdentity)principal.Identity;

        // Thêm tenant claims
        var tenantId = _currentTenant.Id;
        string tenantName = null;
        if (tenantId != null)
        {
            //var tenant = await _currentTenant.GetTenantAsync();
            //tenantName = tenant.Name;
            tenantName = _currentTenant.Name;
        }

        if (tenantId != null)
        {
            identity.AddClaim(new Claim("tenantId", tenantId.ToString(), ClaimValueTypes.String, Destinations.AccessToken));
            identity.AddClaim(new Claim("tenantName", tenantName ?? "", ClaimValueTypes.String, Destinations.AccessToken));
        }

        // Thêm roles
        var roles = await UserManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            identity.AddClaim(new Claim(Claims.Role, role, ClaimValueTypes.String, Destinations.AccessToken));
        }

        // Thêm profile claims
        identity.AddClaim(new Claim(Claims.Name, user.Name ?? "", ClaimValueTypes.String, Destinations.AccessToken));
        identity.AddClaim(new Claim(Claims.Email, user.Email ?? "", ClaimValueTypes.String, Destinations.AccessToken));

        // Tạo authorization (dùng cho refresh token)
        ImmutableArray<string> scopes = ImmutableArray.Create(Scopes.Profile, Scopes.Email, Scopes.Roles, Scopes.OpenId, Scopes.OfflineAccess, "Bamboo");
        var application = await ApplicationManager.FindByClientIdAsync(input.ClientId) ??
            throw new InvalidOperationException(L["DetailsConcerningTheCallingClientApplicationCannotBeFound"]);

        var authorization = await AuthorizationManager.CreateAsync(
            identity,
            //subject: user.Id.ToString(),
            subject: await UserManager.GetUserIdAsync(user),
            client: await ApplicationManager.GetIdAsync(application),
            type: AuthorizationTypes.Permanent,
            scopes: scopes
        );
        var authorizationId = await AuthorizationManager.GetIdAsync(authorization);
        principal.SetAuthorizationId(authorizationId);

        // var request = await GetOpenIddictServerRequestAsync(HttpContext);
        // await OpenIddictClaimsPrincipalManager.HandleAsync(request, principal);
        return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        /*
                // Tạo Access Token
                var accessDescriptor = new OpenIddictTokenDescriptor
                {
                    Principal = principal,
                    Type = TokenTypes.Bearer,
                    AuthorizationId = authorizationId,
                    CreationDate = DateTimeOffset.UtcNow,
                    ExpirationDate = DateTimeOffset.UtcNow.AddHours(1)
                };
                var accessToken = await TokenManager.CreateAsync(accessDescriptor);

                // Tạo Refresh Token
                var refreshDescriptor = new OpenIddictTokenDescriptor
                {
                    Principal = principal,
                    Type = TokenTypes.Bearer,
                    AuthorizationId = authorizationId,
                    CreationDate = DateTimeOffset.UtcNow,
                    ExpirationDate = DateTimeOffset.UtcNow.AddDays(30)
                };
                var refreshToken = await TokenManager.CreateAsync(refreshDescriptor);


                // Trả về DTO
                var dto = new LoginResultDto
                {
                    //AccessToken = await TokenManager.GetIdAsync(accessToken),
                    //RefreshToken = await TokenManager.GetIdAsync(refreshToken),
                    AccessToken = await TokenManager.GetPayloadAsync(accessToken),
                    RefreshToken = await TokenManager.GetPayloadAsync(refreshToken),

                    ExpiresIn = 3600,
                    TenantId = tenantId,
                    TenantName = tenantName,
                    Roles = roles.ToArray(),
                    Profile = new
                    {
                        fullName = user.Name,
                        email = user.Email
                    }
                };

                return Ok(dto);
                */
    }

}

public class LoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; } // nếu cần
}

public class LoginResultDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }

    public Guid? TenantId { get; set; }
    public string TenantName { get; set; }

    public string[] Roles { get; set; }

    public object Profile { get; set; }
}


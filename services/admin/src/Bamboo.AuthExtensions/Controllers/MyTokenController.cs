using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;


using OpenIddict.Server.AspNetCore;
using OpenIddict.Abstractions;
using OpenIddict.Validation;

using Volo.Abp.DependencyInjection;
using Volo.Abp.OpenIddict.Controllers;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.TenantManagement;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

using IdentityRole = Volo.Abp.Identity.IdentityRole;

using Bamboo.Admin;
using Bamboo.Admin.Domain.Shared.Enums;

namespace Bamboo.Admin.Controllers
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(TokenController))]
    public class MyTokenController : TokenController
    {
        private readonly SignInManager<Volo.Abp.Identity.IdentityUser> _signInManager;
        private readonly IdentityUserManager _userManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly ITenantRepository _tenantRepository;
        private readonly IRepository<TenantMember, Guid> _tenantMemberRepo;
        private readonly IReadOnlyRepository<Volo.Abp.Identity.IdentityRole, Guid> _roleRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        //Dùng Validation Service để check Signature
        private readonly OpenIddictValidationService _validationService;

        public MyTokenController(
            ITenantRepository tenantRepository,
            IRepository<TenantMember, Guid> tenantMemberRepo,
            IReadOnlyRepository<IdentityRole, Guid> roleRepository,
            SignInManager<Volo.Abp.Identity.IdentityUser> signInManager,
            IdentityUserManager userManager,
            IAsyncQueryableExecuter asyncExecuter,
            OpenIddictValidationService validationService,
            ICurrentTenant currentTenant)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tenantRepository = tenantRepository;
            _roleRepository = roleRepository;
            _tenantMemberRepo = tenantMemberRepo;
            _currentTenant = currentTenant;
            _asyncExecuter = asyncExecuter;
            _validationService = validationService;
        }

        public override async Task<IActionResult> HandleAsync()
        {
            // 1. Lấy Request OpenIddict
            var request = HttpContext.GetOpenIddictServerRequest();

            // 2. Kiểm tra nếu là "switch_tenant" thì xử lý riêng
            if (request.GrantType == "switch_tenant")
            {
                return await HandleSwitchTenantAsync(request);
            }

            // 3. Nếu không phải, gọi hàm gốc của ABP (cho password, refresh_token...)
            return await base.HandleAsync();
        }

        private async Task<IActionResult> HandleSwitchTenantAsync(OpenIddictRequest request)
        {
            // --- LOGIC TỪ HANDLE CŨ CHUYỂN VÀO ĐÂY ---

            // 1. Lấy tham số (bạn nên dùng access_token trong body thay vì header để đúng chuẩn)
            var accessToken = request.GetParameter("access_token")?.ToString();
            // Nếu bạn vẫn dùng Header Authorization thì dùng:
            // var authResult = await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            var targetTenantIdStr = request.GetParameter("tenant_id")?.ToString();

            // Validate dữ liệu...
            if (string.IsNullOrEmpty(targetTenantIdStr))
            {
                return Forbid(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
            Guid.TryParse(targetTenantIdStr, out var targetTenantId);

            // 2. Validate Token cũ (nếu dùng access_token trong body)
            // Lưu ý: Nếu dùng Header, HttpContext.User đã có sẵn ClaimsPrincipal
            // var principal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;
            // if (principal == null)
            // {
            //     return Challenge(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            // }
            // var currentUserId = principal.FindUserId(); // Extension của ABP

            ClaimsPrincipal principalFromToken;
            try
            {
                principalFromToken = await _validationService.ValidateAccessTokenAsync(accessToken);
            }
            catch (Exception)
            {
                //context.Reject(OpenIddictConstants.Errors.InvalidGrant, "Invalid or expired access token.");
                return BadRequest(new OpenIddictResponse { Error = "Invalid or expired access token." });
            }
            var userId = principalFromToken.FindUserId();
            // 3. Tìm User ở Tenant mới
            // Vì Controller của ABP tự mở UnitOfWork, ta chỉ cần switch context
            //     using (_currentTenant.Change(targetTenantId))
            //     {
            //         var tenant = await _tenantRepository.FindAsync(targetTenantId);
            //         if (tenant == null)
            //         {
            //             return BadRequest(new OpenIddictResponse { Error = "invalid_tenant" });
            //         }

            //         var user = await _userManager.FindByIdAsync(currentUserId.ToString());
            //         if (user == null)
            //         {
            //             return BadRequest(new OpenIddictResponse { Error = "user_not_found_in_tenant" });
            //         }

            //         // 4. Tạo Principal mới (Ticket đăng nhập)
            //         var newPrincipal = await _userManager.CreateUserPrincipalAsync(user);

            //         // Quan trọng: Gán lại Scope cũ hoặc Scope user yêu cầu
            //         var scopes = request.GetScopes();
            //         newPrincipal.SetScopes(scopes);

            //         // Set Resources (Audiences)
            //         newPrincipal.SetResources(await GetResourcesAsync(request.GetScopes()));

            //         // 5. Trả về SignIn (OpenIddict sẽ tự sinh Token mới)
            //         return SignIn(newPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            //     }
            // }
            //using (var uow = _unitOfWorkManager.Begin())
            {
                List<string> memberRoles = [];
                TenantMember? member;
                string tenantName = string.Empty;
                using (_currentTenant.Change(targetTenantId))
                {
                    var tenant = await _tenantRepository.FindAsync(targetTenantId);
                    if (tenant == null)
                    {
                        return BadRequest(new OpenIddictResponse { Error = "invalid_tenant" });
                    }
                    tenantName = tenant.Name; // Lưu lại tên

                    // Dùng WithDetails() để tải navigation property 'Roles'.
                    var memberQueryable = await _tenantMemberRepo.WithDetailsAsync(m => m.Roles);
                    memberQueryable = memberQueryable.Where(m => m.UserId == userId.Value && m.Status == TenantMemberStatus.Active);
                    var memberEntry = await _asyncExecuter.FirstOrDefaultAsync(memberQueryable);
                    if (memberEntry == null)
                    {
                        //context.Reject(OpenIddictConstants.Errors.AccessDenied, "User is not a member of this tenant.");
                        return BadRequest(new OpenIddictResponse { Error = "user_not_found_in_tenant" });
                    }
                    member = memberEntry;

                    var RoleIds = memberEntry.Roles.Select(r => r.RoleId).ToList();
                    if (RoleIds.Count > 0)
                    {
                        var roleQueryable = await _roleRepository.GetQueryableAsync();
                        var query = roleQueryable.Where(role => RoleIds.Contains(role.Id));
                        // var query = from memberRole in memberEntry?.Roles ?? Enumerable.Empty<TenantMemberRole>()
                        //             join role in roleQueryable on memberRole.RoleId equals role.Id
                        //             select role.Name;

                        memberRoles = await _asyncExecuter.ToListAsync(query.Select(r => r.Name));
                    }
                }

                // --- BƯỚC 3: TẠO TOKEN MỚI ---
                // Lưu ý: Tạo Principal mới từ User gốc để đảm bảo claims tươi mới nhất
                Volo.Abp.Identity.IdentityUser user;
                using (_currentTenant.Change(null))
                {
                    user = await _userManager.GetByIdAsync(userId.Value);
                }

                var newPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                var identity = (ClaimsIdentity)newPrincipal.Identity;

                // Xóa Tenant cũ, Add Tenant mới
                var oldTenantClaim = identity.FindFirst(AbpClaimTypes.TenantId);
                if (oldTenantClaim != null) identity.RemoveClaim(oldTenantClaim);
                identity.AddClaim(new Claim(AbpClaimTypes.TenantId, targetTenantIdStr));
                //identity.AddClaim(new Claim(AbpClaimTypes.UserName, user.UserName));
                identity.AddClaim(new Claim("tenant_name", tenantName));

                // --- A. LOẠI BỎ CÁC CLAIM KHÔNG MONG MUỐN ---
                // Danh sách các loại claim cần xóa
                var claimsToRemove = new[]
                {
                    "AspNet.Identity.SecurityStamp",        // Security Stamp (thường rất dài)
                    OpenIddictConstants.Claims.PhoneNumberVerified, // phone_number_verified
                    OpenIddictConstants.Claims.EmailVerified,       // email_verified
                    "amr"                                   // Authentication method references (tùy chọn xóa nếu muốn gọn)
                };

                foreach (var type in claimsToRemove)
                {
                    // Tìm tất cả claim có type này (dùng ToList để tránh lỗi khi đang modify collection)
                    var unwantedClaims = identity.FindAll(type).ToList();
                    foreach (var c in unwantedClaims)
                    {
                        identity.RemoveClaim(c);
                    }
                }

                // --- B. THÊM SURNAME (HỌ) ---
                if (!string.IsNullOrWhiteSpace(user.Surname))
                {
                    // Chuẩn OIDC dùng "family_name" cho Họ
                    identity.AddClaim(new Claim(OpenIddictConstants.Claims.FamilyName, user.Surname));
                }
                // Reset Roles
                var oldRoleClaims = identity.FindAll(AbpClaimTypes.Role).ToList();
                foreach (var claim in oldRoleClaims) identity.RemoveClaim(claim);

                // if (!string.IsNullOrWhiteSpace(member.Role))
                // {
                //     identity.AddClaim(new Claim(AbpClaimTypes.Role, member.Role));
                // }
                foreach (var roleName in memberRoles)
                {
                    identity.AddClaim(new Claim(AbpClaimTypes.Role, roleName));
                }
                identity.AddClaim(new Claim("tenant_user", "false"));

                // Copy Scopes từ request
                newPrincipal.SetScopes(request.GetScopes());

                var resources = await GetResourcesAsync(request.GetScopes());
                newPrincipal.SetResources(resources);
                foreach (var claim in newPrincipal.Claims)
                {
                    // Mặc định: Claim nào cũng cho vào AccessToken
                    var destinations = new List<string> { OpenIddictConstants.Destinations.AccessToken };

                    string type = claim.Type;

                    // Nếu claim là Email dài ngoằng của .NET, đổi type để check dễ hơn (Optional)
                    if (type == ClaimTypes.Email) type = OpenIddictConstants.Claims.Email;
                    else if (type == ClaimTypes.Name) type = OpenIddictConstants.Claims.Name;
                    else if (type == ClaimTypes.GivenName) type = OpenIddictConstants.Claims.GivenName;
                    else if (type == ClaimTypes.Surname) type = OpenIddictConstants.Claims.FamilyName;
                    else if (type == ClaimTypes.Role) type = OpenIddictConstants.Claims.Role;

                    // 2. Logic quyết định cho vào ID Token
                    bool addToIdToken = false;

                    // A. Các claim chuẩn OIDC (ngắn)
                    if (type == OpenIddictConstants.Claims.Name ||
                        type == OpenIddictConstants.Claims.GivenName || // Tên
                        type == OpenIddictConstants.Claims.FamilyName || // Họ
                        type == OpenIddictConstants.Claims.Email ||
                        type == OpenIddictConstants.Claims.PhoneNumber ||
                        type == OpenIddictConstants.Claims.PreferredUsername ||
                        type == OpenIddictConstants.Claims.Role ||
                        type == "tenant_name" ||           // Custom claim của bạn
                        type == AbpClaimTypes.TenantId ||  // ID Tenant
                        type == "sub")
                    {
                        addToIdToken = true;
                    }

                    // B. Các claim chuẩn .NET (dài) - Phòng hờ trường hợp chưa map ở trên
                    else if (type == ClaimTypes.Name ||
                             type == ClaimTypes.GivenName ||
                             type == ClaimTypes.Surname ||
                             type == ClaimTypes.Email ||
                             type == AbpClaimTypes.Role) // ABP Role thường dùng type này
                    {
                        addToIdToken = true;
                    }

                    if (addToIdToken)
                    {
                        destinations.Add(OpenIddictConstants.Destinations.IdentityToken);
                    }

                    // Gán destination cho claim
                    claim.SetDestinations(destinations);
                }
                return SignIn(newPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
        }
    }
}
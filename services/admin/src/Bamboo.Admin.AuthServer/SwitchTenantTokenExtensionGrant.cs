using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;

using Microsoft.AspNetCore.Identity;
using OpenIddict.Abstractions;
using OpenIddict.Server;
using OpenIddict.Validation; // <--- Namespace quan trọng

using Volo.Abp.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

using Volo.Abp.TenantManagement;
using Volo.Abp.Domain.Repositories;

using Bamboo.Admin;

namespace Bamboo.OpenIddictExtensions
{
    public class SwitchTenantTokenExtensionGrant : IOpenIddictServerHandler<OpenIddictServerEvents.HandleTokenRequestContext>, ITransientDependency
    {
        private readonly IdentityUserManager _userManager;
        private readonly SignInManager<Volo.Abp.Identity.IdentityUser> _signInManager;
        private readonly ITenantRepository _tenantRepository;
        private readonly IRepository<TenantMember, Guid> _tenantMemberRepo;
        private readonly ICurrentTenant _currentTenant;

        // SỬA: Dùng Validation Service để check Signature
        private readonly OpenIddictValidationService _validationService;

        public SwitchTenantTokenExtensionGrant(
            IdentityUserManager userManager,
            SignInManager<Volo.Abp.Identity.IdentityUser> signInManager,
            ITenantRepository tenantRepository,
            IRepository<TenantMember, Guid> tenantMemberRepo,
            ICurrentTenant currentTenant,
            OpenIddictValidationService validationService) // Inject
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tenantRepository = tenantRepository;
            _tenantMemberRepo = tenantMemberRepo;
            _currentTenant = currentTenant;
            _validationService = validationService;
        }

        public async ValueTask HandleAsync(OpenIddictServerEvents.HandleTokenRequestContext context)
        {
            if (context.Request.GrantType != "switch_tenant") return;

            var targetTenantIdStr = context.Request.GetParameter("tenant_id").ToString();
            var accessToken = context.Request.AccessToken;

            if (string.IsNullOrEmpty(targetTenantIdStr) || string.IsNullOrEmpty(accessToken))
            {
                context.Reject(OpenIddictConstants.Errors.InvalidRequest, "Missing tenant_id or access_token.");
                return;
            }

            // --- BƯỚC 1: VALIDATE TOKEN (CHUẨN OPENIDDICT) ---
            // Hàm này sẽ:
            // 1. Kiểm tra chữ ký (Signature) bằng Key của Server.
            // 2. Kiểm tra hạn dùng (Expiration).
            // 3. Trả về Principal chứa User Claims.
            ClaimsPrincipal principalFromToken;
            try
            {
                // SỬA: Hàm này trả về ClaimsPrincipal luôn, không cần chấm .Principal nữa
                principalFromToken = await _validationService.ValidateAccessTokenAsync(accessToken);
            }
            catch (Exception)
            {
                context.Reject(OpenIddictConstants.Errors.InvalidGrant, "Invalid or expired access token.");
                return;
            }

            // SỬA: FindUserId() trả về Guid?, cần check null
            var userId = principalFromToken.FindUserId();

            if (userId == null)
            {
                context.Reject(OpenIddictConstants.Errors.InvalidGrant, "Token does not contain User Id.");
                return;
            }
            if (userId == null)
            {
                context.Reject(OpenIddictConstants.Errors.InvalidGrant, "Token does not contain user identifier.");
                return;
            }

            if (!Guid.TryParse(targetTenantIdStr, out var targetTenantId))
            {
                context.Reject(OpenIddictConstants.Errors.InvalidRequest, "Invalid Tenant Id Format.");
                return;
            }

            // --- BƯỚC 2: CHECK QUYỀN THÀNH VIÊN ---
            string[] memberRoles = Array.Empty<string>();

            using (_currentTenant.Change(targetTenantId))
            {
                var member = await _tenantMemberRepo.FirstOrDefaultAsync(x => x.UserId == userId.Value);
                if (member == null) // || check status
                {
                    context.Reject(OpenIddictConstants.Errors.AccessDenied, "User is not a member of this tenant.");
                    return;
                }
                memberRoles = member.Roles?.ToArray();
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

            // Reset Roles
            var oldRoleClaims = identity.FindAll(AbpClaimTypes.Role).ToList();
            foreach (var claim in oldRoleClaims) identity.RemoveClaim(claim);

            foreach (var roleName in memberRoles)
            {
                identity.AddClaim(new Claim(AbpClaimTypes.Role, roleName));
            }

            // Copy Scopes từ request
            newPrincipal.SetScopes(context.Request.GetScopes());

            context.SignIn(newPrincipal);
        }
    }
}
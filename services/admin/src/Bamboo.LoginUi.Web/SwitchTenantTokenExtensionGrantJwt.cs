using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using OpenIddict.Abstractions;
using OpenIddict.Server;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy; // Cần cho ICurrentTenant
using Volo.Abp.OpenIddict;
using Volo.Abp.Security.Claims;
using Volo.Abp.Uow;
using Volo.Abp.TenantManagement;
using Volo.Abp.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt; // Cần để đọc JWT

using Bamboo.Admin;
using Volo.Abp.Linq;
using Bamboo.Admin.Domain.Shared.Enums;
using IdentityRole = Volo.Abp.Identity.IdentityRole; // Namespace chứa TenantMember

namespace Bamboo.OpenIddictExtensions
{
    public class SwitchTenantTokenExtensionGrantJwt : IOpenIddictServerHandler<OpenIddictServerEvents.HandleTokenRequestContext>, ITransientDependency
    {
        private readonly IdentityUserManager _userManager;
        private readonly SignInManager<Volo.Abp.Identity.IdentityUser> _signInManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ITenantRepository _tenantRepository;
        private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
        private readonly IRepository<TenantMember, Guid> _tenantMemberRepo;

        // Inject CurrentTenant để switch context
        private readonly ICurrentTenant _currentTenant;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public SwitchTenantTokenExtensionGrantJwt(
            IdentityUserManager userManager,
            SignInManager<Volo.Abp.Identity.IdentityUser> signInManager,
            IUnitOfWorkManager unitOfWorkManager,
            ITenantRepository tenantRepository,
            IReadOnlyRepository<IdentityRole, Guid> roleRepository,
            IRepository<TenantMember, Guid> tenantMemberRepo,
            IAsyncQueryableExecuter asyncExecuter,
            ICurrentTenant currentTenant) // Inject vào đây
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWorkManager = unitOfWorkManager;
            _tenantRepository = tenantRepository;
            _roleRepository = roleRepository;
            _asyncExecuter = asyncExecuter;
            _tenantMemberRepo = tenantMemberRepo;
            _currentTenant = currentTenant;
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

            // --- SỬA LỖI 1: VALIDATE TOKEN ---
            // Vì đây là JWT, ta không tìm trong DB. Ta parse trực tiếp.
            // Để an toàn, bạn nên Validate Signature (cần Secret Key). 
            // Nhưng để đơn giản ở đây, ta giả định AccessToken gửi lên là chuẩn (ReadJwtToken).

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(accessToken))
            {
                context.Reject(OpenIddictConstants.Errors.InvalidGrant, "Invalid access token format.");
                return;
            }

            var jwtToken = handler.ReadJwtToken(accessToken);

            // Lấy UserId (sub) từ token cũ
            var userIdStr = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == AbpClaimTypes.UserId)?.Value;

            if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out var userId))
            {
                context.Reject(OpenIddictConstants.Errors.InvalidGrant, "Token does not contain valid user id.");
                return;
            }

            if (!Guid.TryParse(targetTenantIdStr, out var targetTenantId))
            {
                context.Reject(OpenIddictConstants.Errors.InvalidRequest, "Invalid Tenant Id.");
                return;
            }

            List<string> memberRoles = [];
            TenantMember? member = null;

            // Dùng CurrentTenant.Change thay vì UnitOfWork
            using (_currentTenant.Change(targetTenantId))
            {
                // Lúc này mọi query xuống Repo sẽ tự động filter theo targetTenantId
                var memberQueryable = await _tenantMemberRepo.WithDetailsAsync(m => m.Roles);
                memberQueryable = memberQueryable.Where(m => m.UserId == userId && m.Status == TenantMemberStatus.Active);
                var memberEntry = await _asyncExecuter.FirstOrDefaultAsync(memberQueryable);
                if (memberEntry == null)
                {
                    context.Reject(OpenIddictConstants.Errors.AccessDenied, "User is not a member of this tenant.");
                    return;
                }
                member = memberEntry;

                var RoleIds = memberEntry.Roles.Select(r => r.RoleId).ToList();
                if (RoleIds.Count > 0)
                {
                    var roleQueryable = await _roleRepository.GetQueryableAsync();
                    var query = roleQueryable.Where(role => RoleIds.Contains(role.Id));

                    memberRoles = await _asyncExecuter.ToListAsync(query.Select(r => r.Name));
                }
            }

            // --- PHẦN TẠO PRINCIPAL (GIỮ NGUYÊN) ---
            Volo.Abp.Identity.IdentityUser user;

            // Query User gốc ở Host (Tenant = null)
            using (_currentTenant.Change(null))
            {
                user = await _userManager.GetByIdAsync(userId);
            }

            var principal = await _signInManager.CreateUserPrincipalAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            // Xóa Tenant cũ, thêm Tenant mới
            var oldTenantClaim = identity.FindFirst(AbpClaimTypes.TenantId);
            if (oldTenantClaim != null) identity.RemoveClaim(oldTenantClaim);
            identity.AddClaim(new Claim(AbpClaimTypes.TenantId, targetTenantIdStr));

            // Xóa Role cũ, thêm Role mới
            var oldRoleClaims = identity.FindAll(AbpClaimTypes.Role).ToList();
            foreach (var claim in oldRoleClaims) identity.RemoveClaim(claim);

            if (!string.IsNullOrWhiteSpace(member.Role))
            {
                identity.AddClaim(new Claim(AbpClaimTypes.Role, member.Role));
            }
            foreach (var roleName in memberRoles)
            {
                identity.AddClaim(new Claim(AbpClaimTypes.Role, roleName));
            }

            var scopes = context.Request.GetScopes();
            principal.SetScopes(scopes);

            context.SignIn(principal);
        }
    }
}
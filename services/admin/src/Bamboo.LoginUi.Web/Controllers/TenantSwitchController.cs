using Bamboo.Admin;
using Bamboo.Admin.Domain.Shared.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Linq;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.TenantManagement;

namespace Bamboo.Admin.Controllers
{
    [Authorize]
    [Route("Account/Workspaces")]
    public class TenantSwitchController : AbpController
    {

        // Khai báo tên Claim dùng để lưu vết ID User gốc ở Host
        private const string OriginalHostUserIdClaimType = "OriginalHostUserId";
        private readonly AbpAspNetCoreMultiTenancyOptions _multiTenancyOptions;

        private readonly SignInManager<Volo.Abp.Identity.IdentityUser> _signInManager;
        private readonly IdentityUserManager _userManager;

        private readonly ITenantRepository _tenantRepository;
        private readonly IRepository<TenantMember, Guid> _tenantMemberRepo;
        private readonly IReadOnlyRepository<Volo.Abp.Identity.IdentityRole, Guid> _roleRepository;

        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IAsyncQueryableExecuter _asyncExecuter;
        IDataFilter _dataFilter;
        public TenantSwitchController(
            SignInManager<Volo.Abp.Identity.IdentityUser> signInManager,
            IdentityUserManager userManager,
            ITenantRepository tenantRepository,
            IRepository<TenantMember, Guid> tenantMemberRepo,
            IReadOnlyRepository<Volo.Abp.Identity.IdentityRole, Guid> roleRepository,
            ICurrentTenant currentTenant,
            IAsyncQueryableExecuter asyncExecuter,
            IDataFilter dataFilter,
            IOptions<AbpAspNetCoreMultiTenancyOptions> multiTenancyOptions,
            IGuidGenerator guidGenerator)
        {
            _dataFilter = dataFilter;
            _tenantRepository = tenantRepository;
            _tenantMemberRepo = tenantMemberRepo;
            _roleRepository = roleRepository;
            _asyncExecuter = asyncExecuter;
            _userManager = userManager;
            _signInManager = signInManager;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
            _multiTenancyOptions = multiTenancyOptions.Value;
        }

        [HttpPost("Switch")]
        public async Task<IActionResult> SwitchAsync(Guid? targetTenantId)
        {
            // --- TRƯỜNG HỢP 1: MUỐN QUAY VỀ HOST (SYSTEM) ---
            if (targetTenantId == null || targetTenantId == Guid.Empty)
            {
                return await SwitchBackToHostAsync();
            }

            // --- TRƯỜNG HỢP 2: MUỐN SANG TENANT ---
            return await SwitchToTenantAsync(targetTenantId.Value);
        }

        /// <summary>
        /// Xử lý logic chuyển từ Host -> Tenant
        /// </summary>
        private async Task<IActionResult> SwitchToTenantAsync(Guid targetTenantId)
        {
            var currentUserId = CurrentUser.Id;
            if (currentUserId == null) return Challenge();

            TenantMember member;
            string tenantName = string.Empty;
            List<string> memberRoles = new List<string>();
            // 1. Kiểm tra quyền: User Host này có được vào Tenant kia không?
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var tenant = await _tenantRepository.FindAsync(targetTenantId);
                if (tenant == null) throw new UserFriendlyException("Tenant không tồn tại.");
                // member = await _tenantMemberRepo.FirstOrDefaultAsync(x => x.TenantId == targetTenantId && x.UserId == currentUserId.Value && x.Status == TenantMemberStatus.Active);
                // if (member == null)
                // {
                //     throw new UserFriendlyException("Truy cập bị từ chối: Bạn không phải thành viên của Tenant này.");
                // }

            }
            // 2. Lấy thông tin User gốc tại Host (để clone sang tenant)
            Volo.Abp.Identity.IdentityUser hostUser;
            using (_currentTenant.Change(null))
            {
                hostUser = await _userManager.GetByIdAsync(currentUserId.Value);
            }

            // 3. Set Cookie Tenant (để các request sau ABP biết đường vào DB Tenant)
            SetTenantCookie(targetTenantId);

            // 4. Switch Context & Silent Login
            using (_currentTenant.Change(targetTenantId))
            {
                // Lúc này đang ở Tenant DB, ta query bảng TenantMember
                var memberQueryable = await _tenantMemberRepo.WithDetailsAsync(m => m.Roles);

                // Lưu ý: userId ở đây vẫn là ID của user đang login (Host User Id)
                var memberEntry = await _asyncExecuter.FirstOrDefaultAsync(
                    memberQueryable.Where(m => m.UserId == currentUserId.Value && m.Status == TenantMemberStatus.Active)
                );

                if (memberEntry == null)
                {
                    throw new UserFriendlyException("Bạn không phải thành viên của Tenant này.");
                }
                member = memberEntry;

                // Lấy tên Role
                var roleIds = memberEntry.Roles.Select(r => r.RoleId).ToList();
                if (roleIds.Any())
                {
                    var roleQueryable = await _roleRepository.GetQueryableAsync();
                    memberRoles = await _asyncExecuter.ToListAsync(
                        roleQueryable.Where(r => roleIds.Contains(r.Id)).Select(r => r.Name)
                    );
                }
            }

            // --- BƯỚC 4: TẠO PRINCIPAL & TRÁO ĐỔI CLAIMS ---
            var principal = await _signInManager.CreateUserPrincipalAsync(hostUser);
            var identity = (ClaimsIdentity)principal.Identity;

            // 4.1. Set Tenant ID & Name Mới
            var oldTenantClaim = identity.FindFirst(AbpClaimTypes.TenantId);
            if (oldTenantClaim != null) identity.RemoveClaim(oldTenantClaim);

            identity.AddClaim(new Claim(AbpClaimTypes.TenantId, targetTenantId.ToString()));
            identity.AddClaim(new Claim("tenant_name", tenantName));

            var claimsToRemove = new[]
            {
                    "AspNet.Identity.SecurityStamp",        // Security Stamp (thường rất dài)
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
            if (!string.IsNullOrWhiteSpace(hostUser.Surname))
            {
                // Chuẩn OIDC dùng "family_name" cho Họ
                identity.AddClaim(new Claim(OpenIddictConstants.Claims.FamilyName, hostUser.Surname));
            }
            // 4.2. Tráo Role (Xóa Role Host -> Add Role Tenant)
            var oldRoleClaims = identity.FindAll(AbpClaimTypes.Role).ToList();
            foreach (var claim in oldRoleClaims) identity.RemoveClaim(claim);

            foreach (var roleName in memberRoles)
            {
                identity.AddClaim(new Claim(AbpClaimTypes.Role, roleName));
            }

            // 4.3. Lưu vết ID gốc (Security)
            identity.AddClaim(new Claim("OriginalHostUserId", hostUser.Id.ToString()));

            // --- BƯỚC 5: LOGIN ---
            SetTenantCookie(targetTenantId);
            await HttpContext.SignInAsync(
                IdentityConstants.ApplicationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true }
            );

            return Redirect("/");
        }


        /// <summary>
        /// Xử lý logic chuyển từ Tenant -> Về lại Host
        /// </summary>
        private async Task<IActionResult> SwitchBackToHostAsync()
        {
            // 1. Lấy ID gốc từ Claim bảo mật (đã nhúng lúc đi sang)
            var originalHostUserIdClaim = User.FindFirst(OriginalHostUserIdClaimType);

            if (originalHostUserIdClaim == null)
            {
                // Nếu không có claim này nghĩa là user login trực tiếp vào Tenant
                // chứ không phải đi từ Host sang -> Bắt logout hoặc báo lỗi
                await _signInManager.SignOutAsync();
                return Redirect("/Account/Login");
            }

            var hostUserId = Guid.Parse(originalHostUserIdClaim.Value);

            // 2. Xóa Cookie Tenant -> Về context Host
            SetTenantCookie(null);

            using (_currentTenant.Change(null))
            {
                // 3. Tìm User gốc theo ID (An toàn 100%, không sợ trùng tên)
                var hostUser = await _userManager.GetByIdAsync(hostUserId);

                if (hostUser == null)
                {
                    throw new UserFriendlyException("Tài khoản gốc tại Host không còn tồn tại.");
                }

                // 4. Đăng nhập lại vào Host
                await _signInManager.SignInAsync(hostUser, isPersistent: true);
            }
            return Redirect("/Account/Workspaces");
        }

        private void SetTenantCookie(Guid? tenantId)
        {
            var tenantCookieName = _multiTenancyOptions.TenantKey;
            if (tenantId.HasValue)
            {
                // Ghi đè cookie "tenant"
                HttpContext.Response.Cookies.Append(
                    tenantCookieName,
                    tenantId.Value.ToString(),
                    new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Path = "/",
                        HttpOnly = true, // Để JS có thể đọc nếu cần, hoặc true để bảo mật
                        IsEssential = true,
                        Expires = DateTimeOffset.Now.AddDays(365) // Nhớ tenant 1 năm
                    }
                );
            }
            else
            {
                // Xóa cookie để về Host
                HttpContext.Response.Cookies.Delete(tenantCookieName);
            }
        }
    }
}
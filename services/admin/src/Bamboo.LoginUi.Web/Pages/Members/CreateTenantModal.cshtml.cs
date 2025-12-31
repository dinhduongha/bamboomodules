using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bamboo.Admin;
using Bamboo.Admin.Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Linq;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members
{
    public class CreateTenantModalModel : AbpPageModel
    {
        [BindProperty]
        public TenantCreateDto Tenant { get; set; }

        private readonly IdentityLinkUserManager _linkManager;
        private readonly ITenantAppService _tenantAppService;
        private readonly IDataSeeder _dataSeeder;
        private readonly ICurrentTenant _currentTenant;
        private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
        private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;
        private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
        private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;
        private readonly IDataFilter _dataFilter;

        public CreateTenantModalModel(
            ITenantAppService tenantAppService,
            IDataSeeder dataSeeder,
            IdentityLinkUserManager linkManager,
            IRepository<TenantMember, Guid> tenantMemberRepository,
            IReadOnlyRepository<IdentityUser, Guid> userRepository,
            IReadOnlyRepository<Tenant, Guid> tenantRepository,
            IReadOnlyRepository<IdentityRole, Guid> roleRepository,
            IAsyncQueryableExecuter asyncExecuter,
            IDataFilter dataFilter,
            ICurrentTenant currentTenant)
        {
            _linkManager = linkManager;
            _tenantAppService = tenantAppService;
            _dataSeeder = dataSeeder;
            _currentTenant = currentTenant;
            _tenantMemberRepository = tenantMemberRepository;
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
            _roleRepository = roleRepository;
            _asyncExecuter = asyncExecuter;
            _dataFilter = dataFilter;

        }

        public void OnGet()
        {
            Tenant = new TenantCreateDto
            {
                // Gán email mặc định để logic tạo admin hoạt động
                AdminEmailAddress = "admin@dad.vn"
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Tenant.Name) || Tenant.Name.Length < 5 || !Regex.IsMatch(Tenant.Name, "^[a-z0-9]+$"))
            {
                throw new Volo.Abp.UserFriendlyException(L["TenantNameRequirements"]);
            }

            // Gán username cho admin bằng tên tenant
            Tenant.SetProperty("AdminUserName", Tenant.Name);
            Tenant.SetProperty("Description", "");
            var tenantDto = await _tenantAppService.CreateAsync(Tenant);
            await CurrentUnitOfWork.SaveChangesAsync();
            // Chuyển sang context của tenant mới để seed data
            var tenantId = tenantDto.Id;
            using (_currentTenant.Change(tenantDto.Id))
            {
                var adminEmail = Tenant.AdminEmailAddress;
                var adminPassword = Tenant.AdminPassword;

                await _dataSeeder.SeedAsync(new DataSeedContext(tenantDto.Id)
                    .WithProperty(IdentityDataSeedContributor.AdminUserNamePropertyName, Tenant == null ? IdentityDataSeedContributor.AdminUserNameDefaultValue : Tenant.Name)
                    .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, Tenant == null ? adminEmail : IdentityDataSeedContributor.AdminEmailDefaultValue)
                    .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, Tenant == null ? adminPassword : IdentityDataSeedContributor.AdminPasswordDefaultValue)
);
                await CurrentUnitOfWork.SaveChangesAsync();

                var user = new IdentityLinkUserInfo((Guid)CurrentUser.Id, CurrentTenant.Id);
                string adminUserName = Tenant.Name;
                var adminUser = await _userRepository.FirstOrDefaultAsync(x => x.UserName == adminUserName);
                if (adminUser != null)
                {
                    var linkUser = new IdentityLinkUserInfo((Guid)adminUser.Id, tenantId);
                    await _linkManager.LinkAsync(user, linkUser);
                }
            }

            DateTimeOffset now = DateTimeOffset.UtcNow;
            // Tạo member cho current user
            var newMember = new TenantMember(GuidGenerator.Create(), tenantId, CurrentUser.Id.Value, TenantMemberStatus.Pending, InvitationStatus.Pending)
            {
                IsOwner = true,
                IsActive = true,
                Role = "owner",
                TenantName = tenantDto.Name,
                AcceptedAt = now,
                InvitedAt = now,
            };
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var roleNames = new string[] { "owner", "admin", "group_user" };
                var roles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId && roleNames.Contains(r.Name));
                foreach (var role in roles)
                {
                    newMember.AddRole(role.Id, GuidGenerator);
                }
            }

            await _tenantMemberRepository.InsertAsync(newMember);
            await CurrentUnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
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
    public class IdentityUserRoleExtension : IdentityUserRole
    {
        public IdentityUserRoleExtension(Guid userId, Guid roleId, Guid tenantId)
            : base(userId, roleId, tenantId)
        {
        }
        //public static IdentityUser AddExtRole(this IdentityUser user, Guid roleId, Guid tenantId)
        //{
        //    user.Roles.Add(new IdentityUserRole(user.Id, roleId, tenantId));
        //    return user;
        //}
    }
    public class CreateTenantModalModel : AbpPageModel
    {
        [BindProperty]
        public TenantCreateDto Tenant { get; set; }

        private readonly IdentityLinkUserManager _linkManager;
        private readonly ITenantAppService _tenantAppService;
        private readonly ITenantManager _tenantManager;
        private readonly ITenantRepository _tenantRepository;

        private readonly IdentityUserManager _userManager;
        private readonly IReadOnlyRepository<IdentityUser, Guid> _userRepository;

        //private readonly IRepository<IdentityUserRole> _userRoleManager;

        private readonly IDataSeeder _dataSeeder;
        private readonly IDataFilter _dataFilter;

        private readonly ICurrentTenant _currentTenant;
        private readonly IRepository<TenantMember, Guid> _tenantMemberRepository;
        //private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
        private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public CreateTenantModalModel(
            IDataSeeder dataSeeder,
            IDataFilter dataFilter,
            ITenantAppService tenantAppService,
            ITenantManager tenantManager,
            ITenantRepository tenantRepository,
            IdentityLinkUserManager linkManager,
            IdentityUserManager userManager,
            IReadOnlyRepository<IdentityUser, Guid> userRepository,
            //IReadOnlyRepository<Tenant, Guid> tenantRepository,
            IReadOnlyRepository<IdentityRole, Guid> roleRepository,
            //IRepository<IdentityUserRole> userRoleManager,
            IRepository<TenantMember, Guid> tenantMemberRepository,
            IAsyncQueryableExecuter asyncExecuter,
            ICurrentTenant currentTenant)
        {
            _tenantAppService = tenantAppService;
            _tenantManager = tenantManager;
            _linkManager = linkManager;
            _userManager = userManager;
            //_userRoleManager = userRoleManager;
            _dataSeeder = dataSeeder;
            _dataFilter = dataFilter;
            _currentTenant = currentTenant;
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _tenantMemberRepository = tenantMemberRepository;
            _asyncExecuter = asyncExecuter;

        }

        public void OnGet()
        {
            Tenant = new TenantCreateDto
            {
                // Gán email mặc định để logic tạo admin hoạt động
                AdminEmailAddress = $"admin@dad.vn"
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

            var tenant = await _tenantManager.CreateAsync(Tenant.Name);
            //Tenant.MapExtraPropertiesTo(tenant);

            await _tenantRepository.InsertAsync(tenant);

            //var tenantDto = await _tenantAppService.CreateAsync(Tenant);
            await CurrentUnitOfWork.SaveChangesAsync();
            var tenantDto = await _tenantAppService.GetAsync(tenant.Id);

            // Chuyển sang context của tenant mới để seed data
            var tenantId = tenantDto.Id;
            var creator = await _userManager.FindByIdAsync(CurrentUser.Id.ToString());
            ;

            using (_currentTenant.Change(tenantDto.Id))
            {
                var adminEmail = Tenant.AdminEmailAddress;
                var adminPassword = Tenant.AdminPassword;
                var adminName = Tenant.Name;

                await _dataSeeder.SeedAsync(new DataSeedContext(tenantDto.Id)
                    .WithProperty(IdentityDataSeedContributor.AdminUserNamePropertyName, Tenant == null ? IdentityDataSeedContributor.AdminUserNameDefaultValue : Tenant.Name)
                    .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, Tenant == null ? adminEmail : IdentityDataSeedContributor.AdminEmailDefaultValue)
                    .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, Tenant == null ? adminPassword : IdentityDataSeedContributor.AdminPasswordDefaultValue)
);
                await _userManager.AddToRolesAsync(creator, ["owner", "admin"]);

                await CurrentUnitOfWork.SaveChangesAsync();

                var adminRoleNames = new string[] { "owner", "admin" };
                var adminRoles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId && adminRoleNames.Contains(r.Name));
                foreach (var role in adminRoles)
                {
                    var userRole = new IdentityUserRoleExtension(creator.Id, role.Id, tenantId);
                    var roleInsert = userRole as IdentityUserRole;
                    //await _userRoleManager.InsertAsync(userRole);
                }

                // Link current user với admin của tenant
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
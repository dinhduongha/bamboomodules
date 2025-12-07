using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members
{
    public class CreateUserModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUserViewModel User { get; set; }

        public List<SelectListItem> Tenants { get; set; }
        public List<SelectListItem> Roles { get; set; }

        private readonly IIdentityUserAppService _userAppService;
        private readonly IReadOnlyRepository<Tenant, Guid> _tenantRepository;
        private readonly IReadOnlyRepository<IdentityRole, Guid> _roleRepository;
        private readonly IDataFilter _dataFilter;

        public CreateUserModalModel(
            IIdentityUserAppService userAppService,
            IReadOnlyRepository<Tenant, Guid> tenantRepository,
            IReadOnlyRepository<IdentityRole, Guid> roleRepository,
            IDataFilter dataFilter)
        {
            _userAppService = userAppService;
            _tenantRepository = tenantRepository;
            _roleRepository = roleRepository;
            _dataFilter = dataFilter;
            Roles = new List<SelectListItem>();
        }

        public async Task OnGetAsync()
        {
            User = new CreateUserViewModel();
            using (_dataFilter.Disable<IMultiTenant>())
            {
                var tenants = await _tenantRepository.GetListAsync();
                Tenants = tenants.Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
                Tenants.Insert(0, new SelectListItem("Host", null)); // Add Host option

                // Tải tất cả các vai trò của tất cả các tenant
                var allRoles = await _roleRepository.GetListAsync();
                Roles = allRoles.Select(r => new SelectListItem(r.Name, r.Name)).ToList();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userDto = ObjectMapper.Map<CreateUserViewModel, IdentityUserCreateDto>(User);
            if (User.RoleName != null)
            {
                userDto.RoleNames = new[] { User.RoleName };
            }

            using (CurrentTenant.Change(User.TenantId))
            {
                await _userAppService.CreateAsync(userDto);
            }
            return NoContent();
        }

        public class CreateUserViewModel : IdentityUserCreateDto
        {
            public Guid? TenantId { get; set; }
            public string RoleName { get; set; }
        }
    }
}
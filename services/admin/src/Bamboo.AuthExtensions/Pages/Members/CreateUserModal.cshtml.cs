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
        //public ICurrentTenant CurrentTenant { get; }

        public CreateUserModalModel(
            IIdentityUserAppService userAppService,
            IReadOnlyRepository<Tenant, Guid> tenantRepository,
            IReadOnlyRepository<IdentityRole, Guid> roleRepository,
            //ICurrentTenant currentTenant,
            IDataFilter dataFilter)
        {
            _userAppService = userAppService;
            _tenantRepository = tenantRepository;
            _roleRepository = roleRepository;
            _dataFilter = dataFilter;
            //CurrentTenant = currentTenant;
            Roles = new List<SelectListItem>();
        }

        public async Task OnGetAsync()
        {
            User = new CreateUserViewModel();
            if (CurrentTenant.IsAvailable)
            {
                // Nếu là admin của tenant, tải sẵn danh sách vai trò của tenant đó
                var roles = await _roleRepository.GetListAsync();
                Roles = roles.Select(r => new SelectListItem(r.Name, r.Name)).ToList();
            }
            else
            {
                // Nếu là Host, chỉ tải danh sách tenant. Roles sẽ được tải bằng AJAX.
                using (_dataFilter.Disable<IMultiTenant>())
                {
                    var tenants = await _tenantRepository.GetListAsync();
                    Tenants = tenants.Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
                    Tenants.Insert(0, new SelectListItem("Host", null)); // Add Host option
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Nếu là admin của tenant, TenantId sẽ là null, ta gán nó bằng tenant hiện tại
            var tenantId = CurrentTenant.Id ?? User.TenantId;

            var userDto = ObjectMapper.Map<CreateUserViewModel, IdentityUserCreateDto>(User);
            if (User.RoleName != null)
            {
                userDto.RoleNames = new[] { User.RoleName };
            }

            // Sử dụng CurrentTenant.Change để đảm bảo user được tạo trong đúng tenant
            // (kể cả khi Host tạo cho tenant khác, hoặc admin tenant tự tạo)
            using (CurrentTenant.Change(tenantId))
            {
                await _userAppService.CreateAsync(userDto);
            }
            return NoContent();
        }

        public async Task<JsonResult> OnGetRolesAsync(Guid? tenantId)
        {
            // Tắt bộ lọc đa tenant để có thể truy vấn vai trò của tenant bất kỳ (hoặc host)
            using (_dataFilter.Disable<IMultiTenant>())
            {
                // Lấy các vai trò có TenantId khớp, hoặc là null (cho Host)
                var roles = await _roleRepository.GetListAsync(r => r.TenantId == tenantId);
                return new JsonResult(roles.Select(r => new SelectListItem(r.Name, r.Id.ToString())).ToList());
            }
        }

        public class CreateUserViewModel : IdentityUserCreateDto
        {
            public Guid? TenantId { get; set; }
            public string RoleName { get; set; }
        }
    }
}

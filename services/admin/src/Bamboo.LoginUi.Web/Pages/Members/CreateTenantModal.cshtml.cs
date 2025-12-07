using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation;

namespace Bamboo.Abp.LoginUi.Web.Pages.Admin.Members
{
    public class CreateTenantModalModel : AbpPageModel
    {
        [BindProperty]
        public TenantCreateDto Tenant { get; set; }

        private readonly ITenantAppService _tenantAppService;
        private readonly IDataSeeder _dataSeeder;
        private readonly ICurrentTenant _currentTenant;

        public CreateTenantModalModel(
            ITenantAppService tenantAppService,
            IDataSeeder dataSeeder,
            ICurrentTenant currentTenant)
        {
            _tenantAppService = tenantAppService;
            _dataSeeder = dataSeeder;
            _currentTenant = currentTenant;
        }

        public void OnGet()
        {
            Tenant = new TenantCreateDto
            {
                // Gán email mặc định để logic tạo admin hoạt động
                AdminEmailAddress = "admin@abp.io"
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Gán username cho admin bằng tên tenant
            Tenant.SetProperty("AdminUserName", Tenant.Name);

            var tenantDto = await _tenantAppService.CreateAsync(Tenant);

            // Chuyển sang context của tenant mới để seed data
            using (_currentTenant.Change(tenantDto.Id))
            {
                await _dataSeeder.SeedAsync(new DataSeedContext(tenantDto.Id));
            }

            return NoContent();
        }
    }
}
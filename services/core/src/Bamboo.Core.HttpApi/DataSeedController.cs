using Bamboo.Core.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Core.HttpApi
{
    [Authorize]
    [RemoteService]
    [Route("api/v1/data-seed")]
    public class DataSeedController : AbpController
    {
        private readonly IDataSeedService _dataSeedService;
        private readonly IConfiguration _configuration;
        public DataSeedController(IConfiguration configuration, IDataSeedService dataSeedService)
        {
            _dataSeedService = dataSeedService;
            _configuration = configuration;
        }

        [HttpPost("system")]
        public async Task SeedAsync()
        {
            var defaultGuid = new Guid("00000000-0000-0000-0000-000000000001");
            var folderPaths = _configuration.GetSection("App:SeedData:Path").Get<List<string>>() ?? [];
            var includeDemo = _configuration.GetSection("App:SeedData:Demo").Get<bool>();

            var mainTenant = Guid.TryParse(_configuration.GetSection("App:SeedData:MainTenant").Value, out var tenantId)
                        ? tenantId         // Nếu parse thành công, dùng kết quả
                        : defaultGuid;     // Nếu thất bại, dùng giá trị mặc định
            await _dataSeedService.SeedDataAsync(folderPaths, mainTenant, includeDemo);
        }

        [Authorize(Roles = "superadmin,admin,owner")]
        [HttpPost("tenant")]
        public async Task SeedTenantAsync(Guid tenantId)
        {
            await _dataSeedService.SeedTenantDataAsync(tenantId);
        }

        [Authorize(Roles = "superadmin,admin,owner")]
        [HttpPost("organization")]
        public async Task SeedOrganizationAsync(Guid tenantId, Guid organizationId, string name)
        {
            await _dataSeedService.SeedOrganizationDataAsync(tenantId, organizationId, name);
        }

        [Authorize]
        [HttpPost("user")]
        public async Task SeedUserAsync(Guid? userId, string? name)
        {
            await _dataSeedService.SeedUserDataAsync(userId, name);
        }
    }

}
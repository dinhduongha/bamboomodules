using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/base-import-module/BaseImportModule")]
    public partial class BaseImportModuleController : AbpController
    {
        protected readonly IBaseImportModuleAppService _appService;
        public BaseImportModuleController(IBaseImportModuleAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-module-open")]
        public async Task<IActionResult> ModuleOpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ModuleOpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-dependencies-to-install-names")]
        public async Task<IActionResult> GetDependenciesToInstallNamesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDependenciesToInstallNamesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("import-module")]
        public async Task<IActionResult> ImportModuleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ImportModuleAsync(ids);
            return Ok(result);
        }
    }
    
}
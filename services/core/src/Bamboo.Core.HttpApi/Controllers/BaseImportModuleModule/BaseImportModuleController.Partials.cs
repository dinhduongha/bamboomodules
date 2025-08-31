using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseImportModuleModule
{
    public partial class BaseImportModuleController
    {
        
        [HttpPost]
        [Route("{id}/action-module-open")]
        public async Task<IActionResult> ActionModuleOpenAsync(Guid id)
        {
            var result = await _appService.ModuleOpenAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-dependencies-to-install-names")]
        public async Task<IActionResult> GetDependenciesToInstallNamesAsync(Guid id)
        {
            var result = await _appService.GetDependenciesToInstallNamesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/import-module")]
        public async Task<IActionResult> ImportModuleAsync(Guid id)
        {
            var result = await _appService.ImportModuleAsync(id);
            return Ok(result);
        }
    }
}
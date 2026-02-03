using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class BaseImportModuleController
    {
        
        [HttpPost]
        [Route("action-module-open")]
        public async Task<IActionResult> ActionModuleOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ModuleOpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-dependencies-to-install-names")]
        public async Task<IActionResult> GetDependenciesToInstallNamesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDependenciesToInstallNamesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("import-module")]
        public async Task<IActionResult> ImportModuleAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ImportModuleAsync(ids);
            return Ok(result);
        }
    }
}
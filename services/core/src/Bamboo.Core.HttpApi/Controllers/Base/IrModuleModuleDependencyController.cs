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
    [Route("api/v1/base/IrModuleModuleDependency")]
    public partial class IrModuleModuleDependencyController : AbpController
    {
        protected readonly IIrModuleModuleDependencyAppService _appService;
        public IrModuleModuleDependencyController(IIrModuleModuleDependencyAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("all-dependencies")]
        public async Task<IActionResult> AllDependenciesAsync([FromBody] IrModuleModuleDependencyAllDependenciesRequestDto input)
        {
            var result = await _appService.AllDependenciesAsync(input);
            return Ok(result);
        }
    }
    
}
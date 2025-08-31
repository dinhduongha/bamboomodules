using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrModuleModuleDependencyController
    {
        
        [HttpPost]
        [Route("{id}/all-dependencies")]
        public async Task<IActionResult> AllDependenciesAsync(Guid id, [FromBody] IrModuleModuleDependencyAllDependenciesRequestDto input)
        {
            var result = await _appService.AllDependenciesAsync(id, input.ModuleNames);
            return Ok(result);
        }
    }
}
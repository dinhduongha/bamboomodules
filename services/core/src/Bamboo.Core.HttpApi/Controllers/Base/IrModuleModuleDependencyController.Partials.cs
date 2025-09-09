using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrModuleModuleDependencyController
    {
        
        [HttpPost]
        [Route("{id}/all-dependencies")]
        public async Task<IActionResult> AllDependenciesAsync(Guid id, [FromBody] IrModuleModuleDependencyAllDependenciesRequestDto input)
        {
            var result = await _appService.AllDependenciesAsync(id, input);
            return Ok(result);
        }
    }
}
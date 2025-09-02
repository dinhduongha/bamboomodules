using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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
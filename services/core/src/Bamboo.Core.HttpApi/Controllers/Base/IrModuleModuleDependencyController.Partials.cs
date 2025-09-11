using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrModuleModuleDependencyController
    {
        
        [HttpPost]
        [Route("all-dependencies")]
        public async Task<IActionResult> AllDependenciesAsync(IrModuleModuleDependencyAllDependenciesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AllDependenciesAsync(input);
            return Ok(result);
        }
    }
}
using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrDemoController
    {
        
        [HttpPost]
        [Route("{id}/install-demo")]
        public async Task<IActionResult> InstallDemoAsync(Guid id)
        {
            var result = await _appService.InstallDemoAsync(id);
            return Ok(result);
        }
    }
}
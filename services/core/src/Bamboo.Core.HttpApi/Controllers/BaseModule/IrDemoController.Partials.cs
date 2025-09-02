using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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
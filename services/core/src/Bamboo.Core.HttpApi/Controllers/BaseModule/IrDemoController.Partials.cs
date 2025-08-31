using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
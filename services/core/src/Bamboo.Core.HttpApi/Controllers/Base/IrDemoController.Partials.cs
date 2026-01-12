using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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
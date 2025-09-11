using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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
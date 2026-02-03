using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResDeviceController
    {
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("revoke")]
        public async Task<IActionResult> RevokeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RevokeAsync(ids);
            return Ok(result);
        }
    }
}
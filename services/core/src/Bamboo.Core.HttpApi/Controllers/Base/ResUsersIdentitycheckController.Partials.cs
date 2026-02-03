using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResUsersIdentitycheckController
    {
        
        [HttpPost]
        [Route("action-use-password")]
        public async Task<IActionResult> ActionUsePasswordAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UsePasswordAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run-check")]
        public async Task<IActionResult> RunCheckAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RunCheckAsync(ids);
            return Ok(result);
        }
    }
}